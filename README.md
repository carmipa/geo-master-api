# GeoMasterAPI

## API RESTful desenvolvida em **ASP.NET Core 8** para realizar **cálculos geométricos** em formas 2D e 3D.

## Tecnologias

- **.NET 8 (ASP.NET Core Web API)**
- **Swagger / OpenAPI (Swashbuckle)**
- Arquitetura baseada em **princípios SOLID**
- Padrões de **Clean Code**

---

## Estrutura do Projeto

```
GeoMasterAPI/
├── Controllers/
│ └── CalculosController.cs
├── DTOs/
│ ├── FormaRequest.cs
│ ├── ResultadoDto.cs
│ └── FormasDuplasRequest.cs
├── Models/
│ ├── ICalculos2D.cs
│ ├── ICalculos3D.cs
│ ├── Circulo.cs
│ ├── Retangulo.cs
│ └── Esfera.cs
├── Services/
│ ├── ICalculadoraService.cs
│ └── CalculadoraService.cs
├── Program.cs
└── GeoMasterAPI.csproj
```

---

## Endpoints RESTful

### 🔹 Área

`POST /api/v1/calculos/area`
**Request (círculo)**

```json
{ "tipoForma": "circulo", "propriedades": { "raio": 10 } }
```

**Response**

```json
{ "valor": 314.1592653589793, "unidade": "u²" }
```

### 🔹 Perímetro

`POST /api/v1/calculos/perimetro`
**Request (retângulo)**

```json
{ "tipoForma": "retangulo", "propriedades": { "largura": 5, "altura": 3 } }
```

**Response**

```json
{ "valor": 16, "unidade": "u" }
```

### 🔹 Volume

`POST /api/v1/calculos/volume`
**Request (esfera)**

```json
{ "tipoForma": "esfera", "propriedades": { "raio": 2.5 } }
```

**Response**

```json
{ "valor": 65.44984694978736, "unidade": "u³" }
```

### 🔹 Área Superficial

`POST /api/v1/calculos/superficie`
**Request (esfera)**

```json
{ "tipoForma": "esfera", "propriedades": { "raio": 2.5 } }
```

**Response**

```json
{ "valor": 78.53981633974483, "unidade": "u²" }
```

### 🔹 Forma Contida

`POST /api/v1/calculos/validacoes/forma-contida`
**Request (círculo dentro de retângulo)**

```json
{
  "externa": {
    "tipoForma": "retangulo",
    "propriedades": { "largura": 10, "altura": 8 }
  },
  "interna": { "tipoForma": "circulo", "propriedades": { "raio": 4 } }
}
```

**Response**

```json
true
```

## Como Executar

```bash
# Clonar o repositório
git clone <link-do-repo>

# Entrar na pasta do projeto
cd geo-master-api/GeoMasterAPI

# Restaurar dependências
dotnet restore

# Rodar a aplicação
dotnet run

## Autores
- Amanda Mesquita - RM559177
- Journey Tiago - RM556071
- Paulo André Carminati - RM557881

```
