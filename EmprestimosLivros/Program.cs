using EmprestimosLivros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddControllersWithViews();
//AQUI QUE ELE FAZ A CONEXAO DO BANCO DE DADOS
//CRIA O NOVO SERVER QUE VAI ADICIONAR O DbContext  QUE NESSE CASO SE CHAMA: ApplicationDbContext;
// EM SEGUIDA COLOCAR AS OPTIONS QUE ELE VAI RECEBER///
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
    //Nas options vai usar o sql server(cria a instancia using) e colocar uma configuração no banco, ou seja, a string de conecçao(Defaultconnection)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
