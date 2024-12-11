using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
    options =>
        options.AddPolicy("Acesso Total",
        configs => configs
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin())
);

var app = builder.Build();

app.MapGet("/", () => "Prova Substitutiva Bruno Trevizan Rizzatto");

// http://localhost:5250/api/aluno/cadastrar
app.MapPost("/api/aluno/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Aluno aluno) =>{
    if (ctx.Alunos.Find(aluno.Nome) == null && ctx.Alunos.Find(aluno.Sobrenome) == null)
    {
        ctx.Alunos.Add(aluno);
        ctx.SaveChanges();
        return Results.Created("", aluno);
    }

    return Results.BadRequest("Este aluno já foi cadastrado");
});
// http://localhost:5250/api/icm/cadastrar
app.MapPost("/api/imc/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] IMC imc) =>{
    Aluno? aluno = ctx.Alunos.Find(imc.AlunoId);
    if (aluno == null)
    {
        return Results.NotFound("Aluno não encontrado");
    }
    float calculo_imc = imc.Peso / imc.Altura;

    if (calculo_imc < 18.5){
        imc.Classificacao = "Magreza";
    }else if (calculo_imc >= 18.5 && calculo_imc <= 24.9)
    {
        imc.Classificacao = "Normal";
    }else if (calculo_imc >= 25.0 && calculo_imc <= 29.9)
    {
        imc.Classificacao = "Sobreeso";
    }else if (calculo_imc >= 30.0 && calculo_imc <= 39.9)
    {
        imc.Classificacao = "Obesidade";
    }else if (calculo_imc > 40){
        imc.Classificacao = "Obesidade grave";
    }

    imc.Aluno = aluno;
    ctx.IMCs.Add(imc);
    ctx.SaveChanges();
    return Results.Created("", imc);

   
});
// http://localhost:5250/api/icm/listar
app.MapGet("/api/imc/listar", ([FromServices] AppDataContext ctx) =>{
    if (ctx.IMCs.Any()){
        return Results.Ok(ctx.IMCs.ToList());
    }
    return Results.NotFound("Nenhum IMC encontrado");
});
// http://localhost:5250/api/icm/listarporaluno/{id}
app.MapGet("/api/imc/listarporaluno/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>{
    if (ctx.IMCs.Any()){
        return Results.Ok(ctx.IMCs.Where(x => x.AlunoId == id));
    }
    return Results.NotFound("Nenhum aluno encontrado");
});
// http://localhost:5250/api/alterar/{id}
app.MapPut("/api/imc/alterar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>{
    IMC? imc = ctx.IMCs.Find(id);

    if (imc is null)
    {
        return Results.NotFound("Nunhum IMC encontrado");
    }

    ctx.IMCs.Update(imc);
    ctx.SaveChanges();
    return Results.Ok(ctx.IMCs.ToList());
});

app.UseCors("Acesso Total");

app.Run();
