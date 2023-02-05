using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PdfSharpCore.Drawing;
using PDFSigner.Data.Entities;
using PDFSigner.Data.Repositories.Interfaces;
using PDFSigner.DTOs;
using PDFSigner.QRCode;

namespace PDFSigner.Data.Repositories
{
    public class DocumentRepository : BaseRepository<Document, Context>, IDocumentRepository
    {
        private readonly Position _position = new QRPosition(55, 690, 50, 0);
        private readonly string fileDirectory = "D:\\PDFFiles";
        private readonly Context _context;
        private IQRCodePlacer _qrCodePlacer;

        public DocumentRepository(Context context, IQRCodePlacer qrCodePlacer) : base(context)
        {
            this._context = context;
            this._qrCodePlacer = qrCodePlacer;
        }

        public override Task<Document> InsertAsync(Document entity)
        {
            var uri = new Uri(entity.FilePath);
            entity.DocumentURL = uri.AbsoluteUri;
            return base.InsertAsync(entity);
        }

        public async Task<Document> SignAsync(int id)
        {
            var toSign = _context.Documents
                .Where(d => d.Id == id)
                .Include(sc => sc.SignCompanies)
                .ThenInclude(sc => sc.SignCompany)
                .FirstOrDefault();
            var viewedCompanies = toSign.SignCompanies.ToList();

            if (viewedCompanies.Count == 0)
            {
                throw new Exception("No signing companies");
            }
            if (viewedCompanies.Where(c => c.IsViewed == false).ToList().Count == 0)
            {
                var layout = _position;
                foreach (var company in viewedCompanies)
                {
                    var qrPath = _qrCodePlacer.GenerateQR(
                        $"{company.SignCompany.Name}\n{company.SignCompany.PhoneNumber}\n{company.SignCompany.Details}",
                        $"{fileDirectory}\\QRCodes\\{company.DocumentId}-{company.CompanyId}.jpg");
                    _qrCodePlacer.PlaceQRToPdf(qrPath, $"{toSign.FilePath}", $"{company.SignCompany.Name}", layout);
                    layout.X += 365;
                }
                toSign.IsSigned = true;
            }

            var result = _context.Update(toSign);
            await _context.SaveChangesAsync();
            return _context.Documents.Where(doc => doc.Id == id).FirstOrDefault();
        }

        public async Task<CompanyDocument> AddSigner(int companyId, int documentId)
        {
            var signer = _context.CompanyDocuments
                .Where(x => x.CompanyId == companyId && x.DocumentId == documentId)
                .SingleOrDefault();
            if (signer != null)
            {
                throw new Exception("Signer already added");
            }
            var document = _context.Documents
                .Where(d => d.Id == documentId)
                .SingleOrDefault();
            var company = _context.Companies
                .Where(c => c.Id == companyId)
                .SingleOrDefault();
            var signDocument = new CompanyDocument();

            if (document != null && company != null)
            {
                signDocument.SignDocument = document;
                signDocument.SignCompany = company;
                signDocument.IsViewed = false;
            }
            else
            {
                throw new Exception("Company or document not found");
            }
            _context.CompanyDocuments.Add(signDocument);
            await _context.SaveChangesAsync();
            return _context.CompanyDocuments
                .Where(d => d.DocumentId == documentId && d.CompanyId == companyId)
                .SingleOrDefault();
        }

        public async Task<CompanyDocument> ViewDocument(int companyId, int documentId)
        {
            var document = _context.Documents
                .Where(d => d.Id == documentId)
                .SingleOrDefault();
            var company = _context.Companies
                .Where(c => c.Id == companyId)
                .SingleOrDefault();

            if (document != null && company != null)
            {
                var viewed = _context.CompanyDocuments
                    .Where(cd => cd.CompanyId == companyId && cd.DocumentId == documentId)
                    .FirstOrDefault();
                viewed.IsViewed = true;
                _context.CompanyDocuments.Update(viewed);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Company or document not found");
            }
            return _context.CompanyDocuments.Where(d => d.DocumentId == documentId && d.CompanyId == companyId).SingleOrDefault();
        }
    }
}
