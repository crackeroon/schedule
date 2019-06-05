

.PHONY: help build restore run

help:
	echo "Usage:"
	echo "restore - install deps"
	echo "build - build project"
	echo "run - start project"

restore:
	dotnet restore timetable/timetable.csproj

build:
	dotnet build

run: build
	dotnet run server.urls=http://0.0.0.0:5000 -p timetable

migrate:
	dotnet ef database -p timetable -s timetable update
