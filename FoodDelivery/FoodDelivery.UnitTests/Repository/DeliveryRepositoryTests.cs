using ElectronicMenu.UnitTests.Repository;
using FluentAssertions;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;
using NUnit.Framework;

namespace FoodDelivery.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class DeliveryRepositoryTests : RepositoryTestsBase
{
    [Test]
    public void GetAllDeliveriesTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var deliveries = new DeliveryEntity[]
        {
        new DeliveryEntity()
        {
            Title = "Sushi Bomba",
            Adress = "Grove Street, 57",
            PhoneNumber = "2-555-777",
            ExternalId = Guid.NewGuid()
        },
        new DeliveryEntity()
        {
            Title = "Pizza Hub",
            Adress = "Free Avenu, 99",
            PhoneNumber = "2-333-111",
            ExternalId = Guid.NewGuid()
        },
        new DeliveryEntity()
        {
            Title = "Burger Club",
            Adress = "Fat Street, 55",
            PhoneNumber = "2-050-707",
            ExternalId = Guid.NewGuid()
        },
        };

        context.Deliveries.AddRange(deliveries);
        context.SaveChanges();

        //execute
        var repository = new Repository<DeliveryEntity>(DbContextFactory);
        var actualDeliveries = repository.GetAll();

        //assert
        actualDeliveries.Should().BeEquivalentTo(deliveries);
    }


    [Test]
    public void GetAllDeliveriesSortedByAdressTest()
    {
        //prepare
        using var context = DbContextFactory.CreateDbContext();
        var deliveries = new DeliveryEntity[]
        {
        new DeliveryEntity()
        {
            Title = "Sushi Bomba",
            Adress = "Grove Street, 57",
            PhoneNumber = "2-555-777",
            ExternalId = Guid.NewGuid()
        },
        new DeliveryEntity()
        {
            Title = "Pizza Hub",
            Adress = "Free Avenu, 99",
            PhoneNumber = "2-333-111",
            ExternalId = Guid.NewGuid()
        },
        new DeliveryEntity()
        {
            Title = "Burger Club",
            Adress = "Fat Street, 17",
            PhoneNumber = "2-050-707",
            ExternalId = Guid.NewGuid()
        },
        };

        context.Deliveries.AddRange(deliveries);
        context.SaveChanges();

        //execute
        var repository = new Repository<DeliveryEntity>(DbContextFactory);
        var actualDeliveries = repository.GetAll(delivery => delivery.Adress.EndsWith("7"));

        //assert
        actualDeliveries.Should().BeEquivalentTo(deliveries.Where(delivery => delivery.Adress.EndsWith("7")));
    }


    [Test]
    public void UpdateDeliveryTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();
        var delivery = new DeliveryEntity()
        {
            Title = "Sushi Bomba",
            Adress = "Grove Street, 57",
            PhoneNumber = "2-555-777",
            ExternalId = Guid.NewGuid()
        };

        context.Deliveries.Add(delivery);
        context.SaveChanges();

        // execute
        delivery.Title = "New Title";
        delivery.Adress = "New Address";
        delivery.PhoneNumber = "9-999-999";
        var repository = new Repository<DeliveryEntity>(DbContextFactory);
        repository.Save(delivery);

        // assert
        var actualDelivery = context.Deliveries.SingleOrDefault();
        actualDelivery.Should().BeEquivalentTo(delivery);
    }


    [Test]
    public void SaveNewDeliveryTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();

        // execute
        var delivery = new DeliveryEntity()
        {
            Title = "Pizza Hub",
            Adress = "Free Avenu, 99",
            PhoneNumber = "2-333-111",
            ExternalId = Guid.NewGuid()
        };

        var repository = new Repository<DeliveryEntity>(DbContextFactory);
        repository.Save(delivery);

        // assert
        var actualDelivery = context.Deliveries.SingleOrDefault();
        actualDelivery.Should().BeEquivalentTo(delivery, options => options.Excluding(x => x.Id)
            .Excluding(x => x.ModificationTime)
            .Excluding(x => x.CreationTime)
            .Excluding(x => x.ExternalId));
        actualDelivery.Id.Should().NotBe(default);
        actualDelivery.ModificationTime.Should().NotBe(default);
        actualDelivery.CreationTime.Should().NotBe(default);
        actualDelivery.ExternalId.Should().NotBe(Guid.Empty);
    }


    [Test]
    public void DeleteDeliveryTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();
        var delivery = new DeliveryEntity()
        {
            Title = "Burger Club",
            Adress = "Fat Street, 55",
            PhoneNumber = "2-050-707",
            ExternalId = Guid.NewGuid()
        };

        context.Deliveries.Add(delivery);
        context.SaveChanges();

        // execute
        var repository = new Repository<DeliveryEntity>(DbContextFactory);
        repository.Delete(delivery);

        // assert
        context.Deliveries.Count().Should().Be(0);
    }


    [Test]
    public void GetByIdDeliveryTest()
    {
        // prepare
        using var context = DbContextFactory.CreateDbContext();
        var deliveries = new DeliveryEntity[]
        {
            new DeliveryEntity()
            {
                Title = "Sushi Bomba",
                Adress = "Grove Street, 57",
                PhoneNumber = "2-555-777",
                ExternalId = Guid.NewGuid()
            },
            new DeliveryEntity()
            {
                Title = "Pizza Hub",
                Adress = "Free Avenu, 99",
                PhoneNumber = "2-333-111",
                ExternalId = Guid.NewGuid()
            },
            new DeliveryEntity()
            {
                Title = "Burger Club",
                Adress = "Fat Street, 55",
                PhoneNumber = "2-050-707",
                ExternalId = Guid.NewGuid()
            },
        };

        context.Deliveries.AddRange(deliveries);
        context.SaveChanges();

        // execute
        var id = deliveries[1].Id;
        var repository = new Repository<DeliveryEntity>(DbContextFactory);
        var actualDelivery = repository.GetById(id);

        // assert
        actualDelivery.Should().BeEquivalentTo(deliveries[1]);
    }


    [Test]
    public void GetByGuidDeliveryTest()
    {
        // prepare 
        var guid = Guid.NewGuid();
        using var context = DbContextFactory.CreateDbContext();
        var deliveries = new DeliveryEntity[]
        {
            new DeliveryEntity()
            {
                Title = "Sushi Bomba",
                Adress = "Grove Street, 57",
                PhoneNumber = "2-555-777",
                ExternalId = Guid.NewGuid()
            },
            new DeliveryEntity()
            {
                Title = "Pizza Hub",
                Adress = "Free Avenu, 99",
                PhoneNumber = "2-333-111",
                ExternalId = guid
            },
            new DeliveryEntity()
            {
                Title = "Burger Club",
                Adress = "Fat Street, 55",
                PhoneNumber = "2-050-707",
                ExternalId = Guid.NewGuid()
            },
        };

        context.Deliveries.AddRange(deliveries);
        context.SaveChanges();

        // execute
        var repository = new Repository<DeliveryEntity>(DbContextFactory);
        var actualDelivery = repository.GetById(guid);

        // assert
        actualDelivery.Should().BeEquivalentTo(deliveries[1]);
    }


    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }


    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }


    public void CleanUp()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.Deliveries.RemoveRange(context.Deliveries);
            context.SaveChanges();
        }
    }
}
