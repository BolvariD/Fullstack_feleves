using BACKEND.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ILoanRepository, LoanRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
