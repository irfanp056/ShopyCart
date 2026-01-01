## Overview
This guide will help you build a microservices-based application using .NET 10 and .NET Aspire

---

## Phase 1: Environment Setup

### Step 1: Install Prerequisites

#### Required Software:
1. **Install .NET 10 SDK**
   - Download from: https://dot.net/download
   - Verify installation: `dotnet --version` (should show 10.x)

2. **Install Docker Desktop**
   - Download from: https://docs.docker.com/engine/install/
   - Start Docker Desktop and ensure it's running
   - Verify: `docker --version`

3. **Install Visual Studio 2026** or **VS Code**
   
   **For Visual Studio:**
   - Workloads to install:
     - ASP.NET and web development
     - .NET Aspire SDK (in Individual Components)
   
   **For VS Code:**
   - Install C# Dev Kit extension
   - Install .NET Aspire extension
---

### Step 1: Explore What Was Created

```
AspireApp2/
├── AspireApp2.AppHost/          # Orchestration project
│   ├── Program.cs                # Service registration
│   └── appsettings.json
├── AspireApp2.ServiceDefaults/  # Shared configuration
│   └── Extensions.cs             # Health checks, telemetry, etc.
├── AspireApp2.ApiService/       # Sample API service
└── AspireApp2.Web/              # Sample web frontend
```
---

## Phase 2: Run Your Application
### Step 1: Build the Solution

```bash
# From the root directory
dotnet build
```

### Step 2: Run with Aspire

```bash
# Run the AppHost project
cd AspireApp2.AppHost
dotnet run
```

### Step 3: Access the Aspire Dashboard

After running, you'll see output like:
```
Login to the dashboard at: http://localhost:19888/login?t=your-token-here
```

The Aspire Dashboard shows:
- All running services
- Logs from each service
- Traces and metrics
- Database connections
- Redis status

---

## Phase 11: Deployment

### Option 1: Deploy to Azure with AZD

```bash
# Install Azure Developer CLI
winget install microsoft.azd

# Initialize and deploy
azd init
azd up
```

### Option 2: Deploy to Kubernetes

```bash
# Generate Kubernetes manifests
dotnet publish /t:GenerateKubernetesResources

# Apply to cluster
kubectl apply -f ./bin/Release/net10.0/publish/
```

---

## Useful Resources

- **.NET Aspire Docs**: https://learn.microsoft.com/dotnet/aspire/
- **Microservices Architecture**: https://learn.microsoft.com/dotnet/architecture/microservices/
- **.NET Aspire Samples**: https://github.com/dotnet/aspire-samples

---

## Common Issues & Solutions

### Issue: "Docker is not running"
**Solution**: Start Docker Desktop before running the AppHost

### Issue: "Port already in use"
**Solution**: Check `appsettings.json` in AppHost and change ports

### Issue: "Service not found"
**Solution**: Ensure service names in AppHost match the HTTP client base addresses

### Issue: "Database connection failed"
**Solution**: Check that the database container is running in Docker

---
