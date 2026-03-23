# 🚀 Product API AOT (.NET)

High-performance **.NET AOT (Ahead-of-Time)** Web API for managing products, designed with **minimal API**, **clean architecture**, and **caching support**.

---

## ✨ Features

- ⚡ Built with **.NET AOT** for faster startup & lower memory usage
- 🧩 Minimal API (lightweight & performant)
- 🗄️ Data access using **Dapper + AOT**
- 🚀 Redis caching support
- 📦 Clean separation: Endpoint → Service → Repository
- 🐳 Docker-ready
- 📄 OpenAPI + Scalar UI

---

## 🏗️ Project Structure

```
ProductApiAot/
│
├── Endpoints/        # API endpoints (Minimal API)
├── Services/         # Business logic
├── Repositories/     # Data access layer
├── Interfaces/       # Contracts
├── Models/           # Domain models
├── Extensions/       # DI & infrastructure setup
├── Serialization/    # AOT JSON context
├── Helpers/          # Utility classes
│
├── Program.cs        # Entry point
└── appsettings.json  # Configuration
```

---

## ⚙️ Tech Stack

- .NET 10 (AOT)
- Dapper + Dapper.AOT
- StackExchange.Redis
- Scalar.AspNetCore (OpenAPI UI)
- Docker

---

## 🚀 Getting Started

### 1. Clone repo

```bash
git clone https://github.com/mahendraputra21/product-api-aot.git
cd product-api-aot
```

---

### 2. Run with .NET

```bash
dotnet run --project ProductApiAot
```

---

### 3. Run with Docker

```bash
docker-compose up --build
```

---

## 🔌 API Endpoints

| Method | Endpoint       | Description       |
| ------ | -------------- | ----------------- |
| GET    | /products      | Get all products  |
| GET    | /products/{id} | Get product by ID |
| POST   | /products      | Create product    |
| PUT    | /products/{id} | Update product    |
| DELETE | /products/{id} | Delete product    |

---

## 📊 Performance (Why AOT?)

- ⚡ Faster cold start
- 🧠 Lower memory footprint
- 📦 Smaller runtime dependencies
- 🚀 Ideal for microservices & containers

---

## 🐳 Docker Notes

Make sure Docker is running, then:

```bash
docker-compose up --build
```

---

## 🧠 Future Improvements

- [ ] Add authentication (JWT)
- [ ] Add rate limiting
- [ ] Add health checks
- [ ] Add observability (OpenTelemetry)
- [ ] Add CI/CD (GitHub Actions)
- [ ] Add integration tests

---

## 🤝 Contributing

Feel free to fork this repo and submit pull requests 🙌

---

## 👨‍💻 Author

Dewa Mahendra  
Backend Engineer (.NET)

---

## ⭐ Support

If you find this project useful, consider giving it a star ⭐
