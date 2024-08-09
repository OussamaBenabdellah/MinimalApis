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
///
/// les verbes HTTP
///

app.MapGet("/get", () => "Hello GET"); 

app.MapDelete("/delete", () =>"Hello DELETE" );

app.MapPost("/post", () => "Hello POST");

app.MapPut("/put", () => "Hello PUT");

app.MapPatch("/patch", () => "Hello PATCH");





app.Run();