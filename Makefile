.PHONY: help build run test lint migration-run migration-add migration-remove clean restore

help:
	@echo "LiteMessenger Makefile"
	@echo ""
	@echo "Available commands:"
	@echo "  make build            - Build the entire solution"
	@echo "  make run              - Run the API project"
	@echo "  make test             - Run Angular tests"
	@echo "  make lint             - Lint Angular code"
	@echo "  make migration-run    - Run EF Core migrations"
	@echo "  make migration-add    - Add a new migration (use MIGRATION=name)"
	@echo "  make migration-remove - Remove last migration"
	@echo "  make clean            - Clean build artifacts"
	@echo "  make restore          - Restore NuGet packages"
	@echo "  make web-build        - Build Angular frontend"
	@echo "  make web-start        - Start Angular dev server"

build:
	dotnet build LiteMessenger.slnx

run:
	dotnet run --project LiteMessenger.Api/

restore:
	dotnet restore LiteMessenger.slnx

clean:
	dotnet clean LiteMessenger.slnx
	rm -rf LiteMessenger.WebUI/dist

test:
	cd LiteMessenger.WebUI && npm test -- --watch=false

lint:
	cd LiteMessenger.WebUI && npm run lint

web-build:
	cd LiteMessenger.WebUI && npm run build

web-start:
	cd LiteMessenger.WebUI && npm start

migration-run:
	dotnet ef database update --project ./LiteMessenger.Application/ --startup-project LiteMessenger.Api/

migration-add:
	dotnet ef migrations add $(MIGRATION) --project ./LiteMessenger.Application/ --startup-project LiteMessenger.Api/

migration-remove:
	dotnet ef migrations remove --project ./LiteMessenger.Application/ --startup-project LiteMessenger.Api/
