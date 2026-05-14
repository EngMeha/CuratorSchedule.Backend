# CuratorSchedule

Backend-система для автоматизации работы куратора учебной группы.  
Микросервисная архитектура на ASP.NET Core с асинхронным взаимодействием через RabbitMQ.

> 🚧 В разработке

## Сервисы

- **GroupService** — управление группами, отслеживание посещаемости мероприятий
- **EventService** — агрегация мероприятий через KudaGo API, категоризация

## Стек

- ASP.NET Core 10 / Clean Architecture
- PostgreSQL + Entity Framework Core
- RabbitMQ + MassTransit
- Docker Compose

## Запуск

```bash
docker compose up
```

> Инструкция будет дополнена по мере разработки.

## Related

- [WebApi.Template](https://github.com/EngMeha/WebApi.Template) — шаблон на котором построены сервисы
