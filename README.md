# Лабораторная работа №2

## Порождающие паттерны проектирования. Фабричный метод и абстрактная фабрика

**Выполнил:** Евсеев В. А.  
**Группа:** 2307А1  
**Проверил:** Макаров М. С.  
**Год:** 2026

---

## Содержание

- [Формулировка задания](#формулировка-задания)
- [Теоретическое обоснование](#теоретическое-обоснование)
- [Описание выполненных действий](#описание-выполненных-действий)
  - [Этап 1. Паттерн «Фабричный метод»](#этап-1-паттерн-фабричный-метод)
  - [Этап 2. Паттерн «Абстрактная фабрика»](#этап-2-паттерн-абстрактная-фабрика)
- [Результат выполненной работы](#результат-выполненной-работы)
- [Исходный код модуля](#исходный-код-модуля)

---

## Формулировка задания

**Тема:** Порождающие паттерны проектирования «Банды Четырех (GoF)»: Фабричный метод и Абстрактная фабрика.

**Цель работы:** Изучить порождающие паттерны проектирования на примере последовательной эволюции архитектуры приложения: от использования простого Фабричного метода к более гибкому паттерну Абстрактная фабрика. На практике освоить принципы объектно-ориентированного проектирования: инкапсуляцию создания объектов, слабую связанность и расширяемость.

**Задание:**  
Разработать оконное приложение с использованием фреймворка WPF, которое позволяет пользователю создавать набор геометрических фигур: круг, квадрат, треугольник. Цвет фигур выбирается из выпадающего списка (красный, синий, зелёный). При изменении выбора все ранее созданные фигуры должны быть удалены и созданы новые соответствующего цвета.

Работа выполняется в **два этапа**, каждый из которых зафиксирован отдельным коммитом в репозитории:
1. **Этап 1.** Реализация с использованием паттерна «Фабричный метод». Для каждого типа фигуры создаётся своя иерархия классов-создателей.
2. **Этап 2.** Рефакторинг до паттерна «Абстрактная фабрика». Все фабричные методы группируются в один интерфейс абстрактной фабрики, объявляющий методы создания всех трёх фигур. Затем создаются конкретные фабрики для каждого цвета, реализующие все три метода. Клиентский код работает только с интерфейсом фабрики.

---

## Теоретическое обоснование

### Паттерн «Фабричный метод» (Factory Method)

**Назначение:**  
Определяет интерфейс для создания объекта, но позволяет подклассам изменять тип создаваемого объекта. Класс делегирует создание объектов своим наследникам.

**Структура:**  
- **Product** (абстрактный продукт) - интерфейс объектов, создаваемых фабричным методом.
- **ConcreteProduct** (конкретный продукт) - реализует интерфейс Product.
- **Creator** (создатель) - объявляет фабричный метод, возвращающий объект типа Product.
- **ConcreteCreator** (конкретный создатель) - переопределяет фабричный метод для создания конкретного продукта.

**Применение в работе:**  
Для каждого типа фигуры (круг, квадрат, треугольник) создаётся своя иерархия создателей. Конкретные создатели для разных цветов переопределяют фабричный метод и возвращают фигуру нужного цвета. Это отделяет код создания фигур от их использования.

### Паттерн «Абстрактная фабрика» (Abstract Factory)

**Назначение:**  
Предоставляет интерфейс для создания семейств взаимосвязанных или взаимозависимых объектов, не специфицируя их конкретные классы.

**Структура:**  
- **AbstractFactory** - объявляет набор фабричных методов для создания каждого типа абстрактных продуктов.
- **ConcreteFactory** - реализует методы AbstractFactory, создавая конкретные продукты (целое семейство).
- **AbstractProduct** - интерфейс для типа продукта.
- **ConcreteProduct** - реализует AbstractProduct.
- **Client** - использует только интерфейсы AbstractFactory и AbstractProduct.

**Применение в работе:**  
Все фабричные методы объединяются в интерфейс `IFigureFactory`. Для каждого цвета создаётся конкретная фабрика (`RedFactory`, `BlueFactory`, `GreenFactory`), реализующая все три метода. Клиентский код (главная форма) работает только с интерфейсом фабрики.

### Взаимосвязь паттернов

Абстрактная фабрика часто реализуется с помощью набора фабричных методов. Каждый метод в интерфейсе абстрактной фабрики - это фабричный метод, отвечающий за создание продукта определённого типа. Конкретная фабрика реализует все эти методы, создавая целое семейство продуктов.

### Ожидаемый результат

На первом этапе будет создано множество иерархий создателей (для каждой фигуры своя), что приведёт к дублированию кода при добавлении нового цвета. На втором этапе код станет более компактным, добавление нового цвета потребует только одного класса фабрики, а клиентский код будет зависеть лишь от абстракций. Это соответствует принципу открытости/закрытости (OCP) и обеспечивает лучшую расширяемость.

---

## Описание выполненных действий

Работа выполнялась в среде **Visual Studio 2022** на языке **C#** с использованием **WPF**. Создано два состояния проекта, зафиксированных в двух коммитах.

### Этап 1. Паттерн «Фабричный метод»

1. **Создание классов фигур (продуктов)**  
   - Абстрактный класс `Figure` с полем `Color` и методом `CreateUIElement()`.
   - Конкретные классы: `Circle` (возвращает `Ellipse`), `Square` (возвращает `Rectangle`), `Triangle` (возвращает `Polygon`).

2. **Создание иерархий создателей**  
   - Абстрактные классы: `CircleCreator`, `SquareCreator`, `TriangleCreator` с методами `Create...()`.
   - Для каждого цвета (красный, синий, зелёный) созданы конкретные создатели, возвращающие фигуру нужного цвета (например, `RedCircleCreator`, `BlueSquareCreator`, `GreenTriangleCreator`). Всего 9 классов.

3. **Разработка главной формы**  
   - XAML: `ComboBox` для выбора цвета, три кнопки, `WrapPanel` для отображения фигур.
   - В коде объявлены поля для текущих создателей (`_currentCircleCreator`, `_currentSquareCreator`, `_currentTriangleCreator`).
   - Обработчик `SelectionChanged` комбобокса: определяет цвет, через `switch` создаёт нужных создателей, очищает панель.
   - Обработчики кнопок: проверяют создателя, создают фигуру, добавляют на панель.

4. **Обработка ошибок**  
   - Добавлена проверка `FiguresPanel?.Children.Clear()` для предотвращения `NullReferenceException`.

### Этап 2. Паттерн «Абстрактная фабрика»

1. **Создание интерфейса абстрактной фабрики**  
   - Интерфейс `IFigureFactory` с методами `CreateCircle()`, `CreateSquare()`, `CreateTriangle()`.

2. **Реализация конкретных фабрик**  
   - Классы `RedFactory`, `BlueFactory`, `GreenFactory`, реализующие интерфейс и возвращающие фигуры соответствующего цвета.

3. **Модификация главной формы**  
   - Поля-создатели заменены одним полем `_currentFactory` типа `IFigureFactory`.
   - Обработчик выбора цвета теперь создаёт нужную фабрику (через `switch`).
   - Обработчики кнопок используют методы текущей фабрики.
   - Очистка панели осталась без изменений.

---

## Результат выполненной работы

### Тестирование

- При запуске приложения по умолчанию выбран красный цвет. Нажатие кнопок добавляет фигуры красного цвета.
- При выборе синего цвета панель очищается, последующие фигуры создаются синими.
- При выборе зелёного цвета - аналогично.
- Все фигуры отображаются корректно, смена цвета работает без ошибок.

### Сравнение с теоретической оценкой

- На первом этапе действительно получилось множество классов (9 создателей), что подтверждает теоретическое предсказание о дублировании иерархий.
- На втором этапе количество классов сократилось до 3 фабрик + интерфейс. Добавление нового цвета потребовало бы только один новый класс, что соответствует принципу OCP.
- Клиентский код стал более компактным и зависит только от абстракций (`IFigureFactory`, `Figure`), что обеспечивает слабую связанность.

**Вывод:** практическая реализация полностью подтвердила теоретические ожидания: абстрактная фабрика обеспечивает лучшую расширяемость при работе с семействами продуктов.

---

## Исходный код модуля

Ниже приведены ключевые файлы проекта. Полный код доступен в репозитории (два коммита в `main`).

### Общие классы фигур (используются в обоих этапах)

**Models/Figure.cs**
```csharp
using System.Windows;
using System.Windows.Media;

namespace FactoryMethodStep.Models  // для первого этапа; во втором - AbstractFactoryStep.Models
{
    public abstract class Figure
    {
        public Color Color { get; set; }
        public abstract UIElement CreateUIElement(double size = 50);
    }
}
```

**Models/Circle.cs**
```csharp
using System.Windows.Media;
using System.Windows.Shapes;

namespace FactoryMethodStep.Models
{
    public class Circle : Figure
    {
        public override UIElement CreateUIElement(double size = 50) =>
            new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color),
                Margin = new Thickness(5)
            };
    }
}
```

**Models/Square.cs** и **Models/Triangle.cs** (аналогично, с использованием `Rectangle` и `Polygon`).

---

### Этап 1. Фабричный метод

**Creators/CircleCreator.cs**
```csharp
using FactoryMethodStep.Models;

namespace FactoryMethodStep.Creators
{
    public abstract class CircleCreator
    {
        public abstract Circle CreateCircle();
    }
}
```

**Creators/RedCircleCreator.cs**
```csharp
using System.Windows.Media;
using FactoryMethodStep.Models;

namespace FactoryMethodStep.Creators
{
    public class RedCircleCreator : CircleCreator
    {
        public override Circle CreateCircle() => new Circle { Color = Colors.Red };
    }
}
```

Аналогично для `BlueCircleCreator`, `GreenCircleCreator`, а также для квадрата и треугольника (всего 9 файлов).

**MainWindow.xaml.cs** (фрагмент)
```csharp
public partial class MainWindow : Window
{
    private CircleCreator _currentCircleCreator;
    private SquareCreator _currentSquareCreator;
    private TriangleCreator _currentTriangleCreator;

    public MainWindow()
    {
        InitializeComponent();
        UpdateCreatorsBasedOnColor("Красный");
    }

    private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ColorComboBox.SelectedItem is ComboBoxItem selectedItem)
        {
            string colorName = selectedItem.Content.ToString();
            UpdateCreatorsBasedOnColor(colorName);
            FiguresPanel?.Children.Clear();
        }
    }

    private void UpdateCreatorsBasedOnColor(string colorName)
    {
        switch (colorName)
        {
            case "Красный":
                _currentCircleCreator = new RedCircleCreator();
                _currentSquareCreator = new RedSquareCreator();
                _currentTriangleCreator = new RedTriangleCreator();
                break;
            case "Синий":
                _currentCircleCreator = new BlueCircleCreator();
                _currentSquareCreator = new BlueSquareCreator();
                _currentTriangleCreator = new BlueTriangleCreator();
                break;
            case "Зелёный":
                _currentCircleCreator = new GreenCircleCreator();
                _currentSquareCreator = new GreenSquareCreator();
                _currentTriangleCreator = new GreenTriangleCreator();
                break;
            default:
                _currentCircleCreator = null;
                _currentSquareCreator = null;
                _currentTriangleCreator = null;
                break;
        }
    }

    private void BtnCircle_Click(object sender, RoutedEventArgs e)
    {
        if (_currentCircleCreator == null) return;
        var circle = _currentCircleCreator.CreateCircle();
        FiguresPanel?.Children.Add(circle.CreateUIElement());
    }

    // Аналогично для BtnSquare_Click и BtnTriangle_Click
}
```

---

### Этап 2. Абстрактная фабрика

**Factories/IFigureFactory.cs**
```csharp
using AbstractFactoryStep.Models;

namespace AbstractFactoryStep.Factories
{
    public interface IFigureFactory
    {
        Circle CreateCircle();
        Square CreateSquare();
        Triangle CreateTriangle();
    }
}
```

**Factories/RedFactory.cs**
```csharp
using System.Windows.Media;
using AbstractFactoryStep.Models;

namespace AbstractFactoryStep.Factories
{
    public class RedFactory : IFigureFactory
    {
        public Circle CreateCircle() => new Circle { Color = Colors.Red };
        public Square CreateSquare() => new Square { Color = Colors.Red };
        public Triangle CreateTriangle() => new Triangle { Color = Colors.Red };
    }
}
```

Аналогично `BlueFactory` и `GreenFactory`.

**MainWindow.xaml.cs** (фрагмент)
```csharp
public partial class MainWindow : Window
{
    private IFigureFactory _currentFactory;

    public MainWindow()
    {
        InitializeComponent();
        UpdateFactoryBasedOnColor("Красный");
    }

    private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ColorComboBox.SelectedItem is ComboBoxItem selectedItem)
        {
            string colorName = selectedItem.Content.ToString();
            UpdateFactoryBasedOnColor(colorName);
            FiguresPanel?.Children.Clear();
        }
    }

    private void UpdateFactoryBasedOnColor(string colorName)
    {
        switch (colorName)
        {
            case "Красный": _currentFactory = new RedFactory(); break;
            case "Синий":   _currentFactory = new BlueFactory(); break;
            case "Зелёный": _currentFactory = new GreenFactory(); break;
            default:        _currentFactory = null; break;
        }
    }

    private void BtnCircle_Click(object sender, RoutedEventArgs e)
    {
        if (_currentFactory == null) return;
        var circle = _currentFactory.CreateCircle();
        FiguresPanel?.Children.Add(circle.CreateUIElement());
    }

    // Аналогично для BtnSquare_Click и BtnTriangle_Click
}
```

