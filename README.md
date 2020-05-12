# Autómatas Finitos
Aplicación C#.NET que permite construir y evaluar autómatas finitos.

## Uso
### Paso 1: Crear Autómata
Se define una nueva instancia de `Automata`.
```csharp
var automata = new Automata();
```

### Paso 2: Crear estados de aceptación y no aceptación
Se definen los estados del autómata, poniendo en el constructor si son estados de aceptación o no.
```csharp
// Estado de aceptación
var estado1 = new Estado(true);

// Estado de no aceptación
var estado2 = new Estado(false);
```

### Paso 3: Crear transiciones entre estados
En este paso se crean las transiciones entre los estados definidos en el paso anterior. Por defecto, el autómata no cambia de estado  si se cumplen dos condiciones:

1) Un estado no tiene una transición definida para una entrada 
2) La entrada está en el alfabeto del autómata


```csharp
// Si está en el estado 1 y lee 'a', pasar al estado 2
estado1.AgregarTransicion('a', estado2);

// Si está en el estado 2 y lee 'b', pasar al estado 1
estado2.AgregarTransicion('b', estado1);
```

### Paso 4 (opcional): Agregar alfabeto
Por defecto, el autómata agrega automáticamente al alfabeto sólo los valores que aparecen en las transiciones. Si desea definir el alfabeto manualmente, puede hacerlo usando:
```csharp
automata.AlfabetoAutomatico = false;
automata.AgregarAlfabeto("ab"); // Agrega 'a' y 'b' al alfabeto
```

### Paso 5: Vincular estados al autómata
En este paso se añaden los estados creados al autómata y se define el estado inicial. Es posible agregar varios estados a la vez.
```csharp
automata.AgregarEstados(estado1, estado2);
automata.SetInicial(estado1);
```
### Paso 6: Evaluar el autómata
La función de Evaluar retorna `true` si la cadena de entrada resulta en un estado de aceptación, y `false` si no.
```csharp
automata.Evaluar("abbbabbaaa");
```