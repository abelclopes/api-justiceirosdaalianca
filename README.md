# api-justiceirosdaalianca
[![Build status](https://ci.appveyor.com/api/projects/status/d0vpva0y5f5vgp3b?svg=true)](https://ci.appveyor.com/project/abelclopes/api-justiceirosdaalianca)


docker build -t api-justiceirosdaalianca .

dotnet ef dbcontext scaffold "Server=localhost;Database=nomedatabase;User=nome_usuario_db;Password=sua_senha;" "Pomelo.EntityFrameworkCore.MySql"

heroku buildpacks:set https://github.com/jincod/dotnetcore-buildpack
