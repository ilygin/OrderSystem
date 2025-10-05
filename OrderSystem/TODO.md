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