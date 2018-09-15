"# api-justiceirosdaalianca" 


docker build -t api-justiceirosdaalianca .

dotnet ef dbcontext scaffold "Server=localhost;Database=nomedatabase;User=nome_usuario_db;Password=sua_senha;" "Pomelo.EntityFrameworkCore.MySql"

heroku buildpacks:set https://github.com/jincod/dotnetcore-buildpack
