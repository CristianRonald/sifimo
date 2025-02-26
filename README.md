# Sifimo

Sifimo es una aplicación desarrollada en C# que requiere .NET para su ejecución. Este documento proporciona los pasos para instalar las dependencias necesarias y ejecutar el programa en Windows, Linux y macOS.

## Requisitos previos
Antes de instalar y ejecutar Sifimo, asegúrese de tener instalado lo siguiente:

- **Windows**: Windows 10/11
- **Linux**: Distribuciones compatibles con .NET (Ubuntu, Debian, Fedora, etc.)
- **macOS**: macOS 10.15 o superior

### Instalación de .NET SDK
Sifimo requiere .NET SDK para compilar y ejecutar el código.

1. Descargue e instale .NET SDK desde [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
2. Verifique la instalación ejecutando el siguiente comando en la terminal o consola:
   ```sh
   dotnet --version
   ```
   Si el comando devuelve un número de versión, la instalación fue exitosa.

## Instalación de Sifimo
### 1. Clonar el repositorio
Abra una terminal o consola y ejecute el siguiente comando:
```sh
git clone https://github.com/CristianRonald/sifimo.git
```

### 2. Navegar al directorio del proyecto
```sh
cd sifimo
```

### 3. Restaurar dependencias
Ejecute el siguiente comando para instalar las dependencias del proyecto:
```sh
dotnet restore
```

## Ejecución del programa

Para ejecutar Sifimo, ejecute el siguiente comando dentro del directorio del proyecto:
```sh
dotnet run
```
Si desea compilar el programa y luego ejecutarlo manualmente:
```sh
dotnet build -o bin
./bin/Sifimo
```

## Generación del ejecutable
Para publicar la aplicación como un ejecutable:
```sh
dotnet publish -c Release -r win-x64 --self-contained true -o publish/
```
Para Linux o macOS, reemplace `win-x64` con `linux-x64` o `osx-x64`.

El ejecutable estará en la carpeta `publish/` y se puede ejecutar directamente.

## Contacto
Para cualquier duda o consulta, por favor contacte a [correo@example.com](mailto:porta.cristianlo@gmail.com).

