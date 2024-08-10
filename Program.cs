using Microsoft.AspNetCore.Mvc;
using MinimalApis;


#region Création d'une API
///
/// WebApplication c'est une class 
/// CreateBuilder une methode de WebApplication qui est static et son type retour est  WebApplicationBuilder
/// 
///
var builder = WebApplication.CreateBuilder();

///
/// création d'un singleton pour géré l'instantiation de la class ArticleServices
/// 
builder.Services.AddSingleton<ArticleServices>();
///
/// Build est une methode de notre variable builder et son type de retour WebApplication
///
var app = builder.Build();
#endregion

#region les verbes HTTP les plus utiliser

app.MapGet("/get", () => "Hello GET"); 

//ce qui suit on peux le voir que on postman 

app.MapDelete("/delete", () => "Hello DELETE");

app.MapPost("/post", () => "Hello POST");

app.MapPut("/put", () => "Hello PUT");

app.MapPatch("/patch", () => "Hello PATCH");

#endregion

#region exemple avec un objet
app.MapGet("/article", () => new Article(1, "Marteau"));
#endregion

#region exemple qu on peut rendre les URL parametrble

//app.MapGet("/articless/{id : int}", (int id) => new Article(id, "Marteau"));
//app.MapGet("/articless/{title : sting}", (string title) => new Article(99999, title));

///
/// Query string  ?inomduparametre='valeurduParametre'
///
app.MapGet("/articless", (int id) => new Article(id, "tour"));

#endregion

#region création liste D'article & les manipuler 


//app.MapGet("/articles/{id:int}", (int id) =>
//{
//    var article = articles.Find(a => a.Id == id);
//    if (article is not null) return Results.Ok(article);// Results.Ok renvois 200ok

//    return Results.NotFound();//Results.NotFound renvois 404
//});
//app.MapGet("/articels/{title}", (string title ) => new Article(999, title));


#endregion
#region Gestion des paramete entrant

//app.MapGet("/personnes/{nom}", (string nom) => Results.Ok($"id ,{nom}")) ;

//avec ? on informe .net que ces parametre peuvent etre null(peuvent etre non renseigner) 
//ex1
//app.MapGet("/personne/{nom?}", (string? nom, string? prenom) => Results.Ok($"{nom} , {prenom}"));
//ex 2
//app.MapGet("/personnes/{nom}", (string nom, string? prenom, int? id) => Results.Ok($"{nom} , {prenom}, {id}"));
//ex3
//app.MapGet("/personne/{nom}", (string nom, string? prenom) => Results.Ok($"{nom} , {prenom}"));

/// on peut definir a .net ou procurer les donnée avec [searchname ??!!]
/// FromRoute : de l'URL
/// FromQuery : de l'URL on ajouttant "?" 
/// FromHeader : du Header 
//app.MapGet("/personne/{nom}", (
//    [FromRoute(Name = "nom")]string nom, 
//    [FromQuery]string? prenom,
//    [FromHeader(Name = "Accept-Encoding")] string encoding ) => Results.Ok($"{nom} , {prenom}"));

#endregion

#region Gestion des parametre avancer 
///recupere des donnée tel que un objet type class

//app.MapGet("/personnesss/identite", (Personne p) => Results.Ok(p));

//crée des donnée complexe "un objet" 

//app.MapPost("/personne/identite", (Personne p) => Results.Ok(p));

#endregion

#region Gestion des service 

app.MapGet("/articles/{id:int}", (int id, ArticleServices services) =>
{
    var article = services.GetAll().Find(a => a.Id ==id);
    if (article is not  null) return Results.Ok(article);

    return Results.NotFound();
});

app.MapPost("/articles", (Article a, ArticleServices services) =>
{
    var result = services.Add(a.Title);
    return Results.Ok(result);
});


#endregion





app.Run();