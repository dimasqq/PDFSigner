

using PDFSigner.Data;
using PDFSigner.Data.Repositories;
using PDFSigner.Data.Repositories.Interfaces;
using PDFSigner.Managers;
using PDFSigner.Managers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<IDocumentManager, DocumentManager>();
builder.Services.AddScoped<ICompanyRepository, ComapnyRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
