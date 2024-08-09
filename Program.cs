using MinimalApis;


#region Création d'une API
///
/// WebApplication c'est une class 
/// CreateBuilder une methode de WebApplication qui est static et son type retour est  WebApplicationBuilder
/// 
///
var builder = WebApplication.CreateBuilder();
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

//app.MapGet("/articles/{id : int}", (int id) => new Article(id, "Marteau"));
//app.MapGet("/articles/{title : sting}", (string title) => new Article(99999, title));
#endregion

#region création liste D'article & les manipuler 

var list = new List<Article>
{
    new(1, "marteau"),
    new(2, "scie")
};

app.MapGet("/articles/{id:int}", (int id) =>
{
    var article = list.Find(a => a.Id == id);
    if (article is not null) return Results.Ok(article);

    return Results.NotFound();
});
app.MapGet("/articels/{title}", (string title) => new Article(999, title));

#endregion








app.Run();