### TODO List

## Фичи и улучшения
- добавить новые объекты в Order. Добавлять по 1-2 объекту за спринт.
	- OrderTypes
	- Payments
	- Customer
	- OrderStatuses
	- Products
- реализовать асинхронные методы в отдельном спринте;
- разные стратегии для удаления задач
- написать валидаторы входящих параметров. Возможно на уровне объектов,dto и тд
- Kubernetes
- Redis
- moq 
## Технический долг
- улучшить валидацию входящих запросов
- обновить тесты
- Использование базового класса Exception не рекомендуется. Лучше создать специфичные типы исключений (например, ArgumentException, InvalidOperationException) или пользовательские исключения для бизнес-логики
- тесты на апи запросы
- The response object initialization pattern is repeated throughout all methods. Consider extracting this into a helper method or using a factory pattern to reduce code duplication.
- Exposing raw exception messages to API consumers can leak sensitive information about the system's internal structure. Consider using generic error messages and logging detailed exceptions internally.
- 

## Идеи для экспериментов
- Внедрить автоматическое тестирование новых функций с помощью CI/CD пайплайна


## Review by Copilot

- The CreateOrder/UpdateOrder methods changed from throwing exceptions to returning Failure results for domain validation errors. There are existing unit tests for OrderService (OrderSystem.Tests/OrderServiceTests.cs), but none currently assert the new Result contract (IsSuccess=false and the expected Message) for invalid inputs like negative amounts or missing customer name. Add tests to cover these new failure paths
- The CreateOrder/UpdateOrder methods changed from throwing exceptions to returning Failure results for domain validation errors. There are existing unit tests for OrderService (OrderSystem.Tests/OrderServiceTests.cs), but none currently assert the new Result contract (IsSuccess=false and the expected Message) for invalid inputs like negative amounts or missing customer name. Add tests to cover these new failure paths.

