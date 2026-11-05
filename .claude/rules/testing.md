---
paths:
  - "tests/**/*.cs"
---

# Tests

Neue Tests orientieren sich an diesem Beispiel, sowohl im Aufbau als auch in der Benennung.

```csharp
namespace Chandlery.Catalog.Api.Tests.Services;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repository;
    private readonly ProductService _target;

    public ProductServiceTests()
    {
        _repository = new Mock<IProductRepository>();
        _target = new ProductService(_repository.Object);
    }

    [Fact]
    public async Task GetById01()
    {
        //arrange
        var unknownId = Guid.NewGuid();
        _repository
            .Setup(r => r.GetById(unknownId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Product?)null);

        //act
        var act = () => _target.GetById(unknownId, CancellationToken.None);

        //assert
        await Assert.ThrowsAsync<NotFoundException>(act);
    }

    [Fact]
    public async Task Create01()
    {
        //arrange
        var model = new CreateProductModel("Fender", 24.90m);
        var wasAddCalled = false;
        _repository
            .Setup(r => r.Add(It.IsAny<Product>(), It.IsAny<CancellationToken>()))
            .Callback(() => wasAddCalled = true)
            .Returns(Task.CompletedTask);

        //act
        await _target.Create(model, CancellationToken.None);

        //assert
        Assert.True(wasAddCalled);
    }
}
```

- Testnamen bestehen aus dem getesteten Methodennamen und einer laufenden Nummer, also `GetById01`, `GetById02`.
- Abhängigkeiten werden mit Moq gemockt.
- Aufrufe werden nicht mit `Verify` geprüft. Stattdessen setzt ein `Callback` eine lokale Variable `was<Method>Called`, die der Test am Ende abfragt.
- Pro Test wird genau ein Verhalten geprüft, gegliedert in Arrange, Act und Assert.
- Integrationstests mit Datenbank oder Kafka nutzen Testcontainers.
