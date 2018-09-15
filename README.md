"# api-justiceirosdaalianca" 


docker build -t api-justiceirosdaalianca .

dotnet ef dbcontext scaffold "Server=mysql.justiceirosdaalianca.com.br;Database=justiceirosdaa;User=justiceirosdaa;Password=n1d2x8;" "Pomelo.EntityFrameworkCore.MySql"