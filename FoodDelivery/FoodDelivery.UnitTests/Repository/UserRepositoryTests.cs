using ElectronicMenu.UnitTests.Repository;
using FluentAssertions;
using FoodDelivery.DataAccess;
using FoodDelivery.DataAccess.Entities;
using NUnit.Framework;

namespace FoodDelivery.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class UserRepositoryTests : RepositoryTestsBase
{
    [Test]
    public void GetAllUsersTest()
    {
        //prepare
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

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Oleg",
                LastName = "Petrov",
                Patronymic = "Sergeevich",
                Birthday = new DateTime(2000, 10, 1),
                PhoneNumber = "89245786510",
                Email = "Oleggg@mail.ru",
                PasswordHash = "password1",
                Adress = "Sunny Street, 23",
                Avatar = "https://img01.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Nikolay",
                LastName = "Andreev",
                Patronymic = "Alexandrovich",
                Birthday = new DateTime(1998, 5, 4),
                PhoneNumber = "89785986520",
                Email = "Niko@yandex.ru",
                PasswordHash = "password2",
                Adress = "Sad Street, 1",
                Avatar = "https://img02.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Boris",
                LastName = "Krutoi",
                Patronymic = "Olegovich",
                Birthday = new DateTime(2003, 10, 4),
                PhoneNumber = "87895214510",
                Email = "BorisKrut@gmail.com",
                PasswordHash = "password3",
                Adress = "Kakaya-to Street, 116",
                Avatar = "https://img03.png"
            },
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        //execute
        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUsers = repository.GetAll();

        //assert
        actualUsers.Should().BeEquivalentTo(users, options => options.Excluding(x => x.Delivery));
    }


    [Test]
    public void GetAllUsersSortedByEmailTest()
    {
        //prepare
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

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Oleg",
                LastName = "Petrov",
                Patronymic = "Sergeevich",
                Birthday = new DateTime(2000, 10, 1),
                PhoneNumber = "89245786510",
                Email = "Oleggg@mail.ru",
                PasswordHash = "password1",
                Adress = "Sunny Street, 23",
                Avatar = "https://img01.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Nikolay",
                LastName = "Andreev",
                Patronymic = "Alexandrovich",
                Birthday = new DateTime(1998, 5, 4),
                PhoneNumber = "89785986520",
                Email = "Niko@yandex.ru",
                PasswordHash = "password2",
                Adress = "Sad Street, 1",
                Avatar = "https://img02.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Boris",
                LastName = "Krutoi",
                Patronymic = "Olegovich",
                Birthday = new DateTime(2003, 10, 4),
                PhoneNumber = "87895214510",
                Email = "BorisKrut@gmail.com",
                PasswordHash = "password3",
                Adress = "Kakaya-to Street, 116",
                Avatar = "https://img03.png"
            },
        };
        context.Users.AddRange(users);
        context.SaveChanges();

        //execute
        var repository = new Repository<UserEntity>(DbContextFactory);
        var filterEmailEnding = ".ru";
        var actualUsersUsingKeySelector = repository.GetAll(user => user.Email.EndsWith(filterEmailEnding));

        //assert
        actualUsersUsingKeySelector.Should().BeEquivalentTo(users
            .Where(user => user.Email.EndsWith(filterEmailEnding)), options => options.Excluding(user => user.Delivery));
    }


    [Test]
    public void UpdateUserTest()
    {
        //prepare
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

        var user = new UserEntity()
        {
            DeliveryId = delivery.Id,
            ExternalId = Guid.NewGuid(),
            FirstName = "Boris",
            LastName = "Krutoi",
            Patronymic = "Olegovich",
            Birthday = new DateTime(2003, 10, 4),
            PhoneNumber = "87895214510",
            Email = "BorisKrut@gmail.com",
            PasswordHash = "password3",
            Adress = "Kakaya-to Street, 116",
            Avatar = "https://img03.png"
        };

        context.Users.Add(user);
        context.SaveChanges();

        //execute
        user.FirstName = "new name";
        user.LastName = "new surname";
        user.Patronymic = "new patronymic";
        user.Avatar = "https://img10.png";
        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        //assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Delivery));
    }


    [Test]
    public void SaveNewUserTest()
    {
        //prepare
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

        //execute
        var user = new UserEntity()
        {
            DeliveryId = delivery.Id,
            ExternalId = Guid.NewGuid(),
            FirstName = "Nikolay",
            LastName = "Andreev",
            Patronymic = "Alexandrovich",
            Birthday = new DateTime(1998, 5, 4),
            PhoneNumber = "89785986520",
            Email = "Niko@yandex.ru",
            PasswordHash = "password2",
            Adress = "Sad Street, 1",
            Avatar = "https://img02.png"
        };

        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        //assert
        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user, options => options.Excluding(x => x.Delivery)
            .Excluding(x => x.Id)
            .Excluding(x => x.ModificationTime)
            .Excluding(x => x.CreationTime)
            .Excluding(x => x.ExternalId));
        actualUser.Id.Should().NotBe(default);
        actualUser.ModificationTime.Should().NotBe(default);
        actualUser.CreationTime.Should().NotBe(default);
        actualUser.ExternalId.Should().NotBe(Guid.Empty);
    }


    [Test]
    public void DeleteUserTest()
    {
        //prepare
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

        var user = new UserEntity()
        {
            DeliveryId = delivery.Id,
            ExternalId = Guid.NewGuid(),
            FirstName = "Oleg",
            LastName = "Petrov",
            Patronymic = "Sergeevich",
            Birthday = new DateTime(2000, 10, 1),
            PhoneNumber = "89245786510",
            Email = "Oleggg@mail.ru",
            PasswordHash = "password1",
            Adress = "Sunny Street, 23",
            Avatar = "https://img01.png"

        };

        context.Users.Add(user);
        context.SaveChanges();

        //execute
        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Delete(user);

        //assert
        context.Users.Count().Should().Be(0);
    }


    [Test]
    public void GetByIdTest()
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

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Oleg",
                LastName = "Petrov",
                Patronymic = "Sergeevich",
                Birthday = new DateTime(2000, 10, 1),
                PhoneNumber = "89245786510",
                Email = "Oleggg@mail.ru",
                PasswordHash = "password1",
                Adress = "Sunny Street, 23",
                Avatar = "https://img01.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Nikolay",
                LastName = "Andreev",
                Patronymic = "Alexandrovich",
                Birthday = new DateTime(1998, 5, 4),
                PhoneNumber = "89785986520",
                Email = "Niko@yandex.ru",
                PasswordHash = "password2",
                Adress = "Sad Street, 1",
                Avatar = "https://img02.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Boris",
                LastName = "Krutoi",
                Patronymic = "Olegovich",
                Birthday = new DateTime(2003, 10, 4),
                PhoneNumber = "87895214510",
                Email = "BorisKrut@gmail.com",
                PasswordHash = "password3",
                Adress = "Kakaya-to Street, 116",
                Avatar = "https://img03.png"
            },
        };

        context.AddRange(users);
        context.SaveChanges();

        // execute
        var id = users[1].Id;
        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUser = repository.GetById(id);

        // assert
        actualUser.Should().BeEquivalentTo(users[1]);
    }


    [Test]
    public void GetByGuidTest()
    {
        // prepare 

        var guid = Guid.NewGuid();
        using var context = DbContextFactory.CreateDbContext();
        var delivery = new DeliveryEntity()
        {
            Title = "Sushi Bomba",
            Adress = "Grove Street, 57",
            PhoneNumber = "2-555-777",
            ExternalId = Guid.NewGuid()
        };

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Oleg",
                LastName = "Petrov",
                Patronymic = "Sergeevich",
                Birthday = new DateTime(2000, 10, 1),
                PhoneNumber = "89245786510",
                Email = "Oleggg@mail.ru",
                PasswordHash = "password1",
                Adress = "Sunny Street, 23",
                Avatar = "https://img01.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Nikolay",
                LastName = "Andreev",
                Patronymic = "Alexandrovich",
                Birthday = new DateTime(1998, 5, 4),
                PhoneNumber = "89785986520",
                Email = "Niko@yandex.ru",
                PasswordHash = "password2",
                Adress = "Sad Street, 1",
                Avatar = "https://img02.png"
            },
            new UserEntity()
            {
                DeliveryId = delivery.Id,
                ExternalId = Guid.NewGuid(),
                FirstName = "Boris",
                LastName = "Krutoi",
                Patronymic = "Olegovich",
                Birthday = new DateTime(2003, 10, 4),
                PhoneNumber = "87895214510",
                Email = "BorisKrut@gmail.com",
                PasswordHash = "password3",
                Adress = "Kakaya-to Street, 116",
                Avatar = "https://img03.png"
            },
        };

        context.AddRange(users);
        context.SaveChanges();

        // execute
        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUser = repository.GetById(guid);

        // assert
        actualUser.Should().BeEquivalentTo(users[1]);
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
            context.Users.RemoveRange(context.Users);
            context.Deliveries.RemoveRange(context.Deliveries);
            context.SaveChanges();
        }
    }
}