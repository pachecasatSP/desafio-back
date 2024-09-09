# entrypoint.sh
#!/bin/bash
set -e

# Executa as migrations
dotnet ef database update --project desafio-back.infrastructure --startup-project desafio-back.api

# Inicia a aplicação
exec dotnet desafio-back.api.dll
