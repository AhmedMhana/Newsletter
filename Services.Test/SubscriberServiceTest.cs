using DatabaseLayer;
using Models;
using Models.Enums;
using Moq;
using NUnit.Framework;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Test
{
    [TestFixture]
    public class SubscriberServiceTest
    {
        private Mock<BaseContext> _contextMock;
        private Mock<UnitOfWork> _unitOfWorkMock;
        private  Mock<GenericRepository<Subscriber>> _repositoryMock;
        private ISubscriberService _subscriberService;

        [OneTimeSetUp]
        public void Setup()
        {
            _contextMock = new Mock<BaseContext>();
            _unitOfWorkMock = new Mock<UnitOfWork>(_contextMock.Object);
            _repositoryMock = new Mock<GenericRepository<Subscriber>>(_contextMock.Object);
        }

        [Test]
        public void GetAll_Calling_ReturnData()
        {
            //Arrange
            IEnumerable<Subscriber> allSubscribers = new List<Subscriber>()
            {
                new Subscriber {Id=Guid.NewGuid(),Email="email1@admin.com",HeardFrom=HeardFromResources.Advert,ReasonForSignup="Advert" },
                new Subscriber {Id=Guid.NewGuid(),Email="email2@admin.com",HeardFrom=HeardFromResources.WordOfMouth,ReasonForSignup="Word Of Mouth" },
                new Subscriber {Id=Guid.NewGuid(),Email="email3@admin.com",HeardFrom=HeardFromResources.Other,ReasonForSignup="Other"},
            };

            _repositoryMock.Setup(md => md.GetAll()).Returns(allSubscribers);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object,_repositoryMock.Object);

            //Act
            var result = _subscriberService.GetAll();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void GetById_Calling_ReturnData()
        {
            //Arrange
            var Id_1 = Guid.NewGuid();
            var actualSubscriber = new Subscriber { Id = Id_1, Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = "Advert" };
            var expectedSubscriber = new Subscriber { Id = Id_1, Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = "Advert" };
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var expectedJson = serializer.Serialize(expectedSubscriber);
            var actualJson = serializer.Serialize(actualSubscriber);

            _repositoryMock.Setup(md => md.GetByID(Id_1)).Returns(actualSubscriber);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object,_repositoryMock.Object);

            //Act
            var result = _subscriberService.GetById(Id_1);

            // Assert
            Assert.AreEqual(expectedJson, actualJson);
        }

        [Test]
        public void GetById_CallingWithObjectNotInDatabase_ReturnNull()
        {
            //Arrange
            var newId = Guid.NewGuid();
            var actualSubscriber = new Subscriber { Id = Guid.NewGuid(), Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = "Advert" };

            _repositoryMock.Setup(md => md.GetByID(actualSubscriber.Id)).Returns(actualSubscriber);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.GetById(newId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Create_Calling_ShouldSave()
        {
            //Arrange
            Subscriber subscriber = new Subscriber { Id = Guid.NewGuid(), Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = "Advert" };

            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            _subscriberService.Create(subscriber);

            // Assert
            _repositoryMock.Verify(md => md.Insert(It.IsAny<Subscriber>()), Times.Once);
        }

        [Test]
        public void Create_CallingWithNullObject_ReturnNull()
        {
            //Arrange
            Subscriber subscriber = null;

            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.Create(subscriber);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Update_Calling_ShouldSave()
        {
            //Arrange
            var Id_1 = Guid.NewGuid();
            var actualSubscriber = new Subscriber { Id = Id_1, Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = "Advert" };

            _repositoryMock.Setup(md => md.GetByID(Id_1)).Returns(actualSubscriber);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            _subscriberService.Update(actualSubscriber);

            // Assert
            _repositoryMock.Verify(md => md.Update(It.IsAny<Subscriber>()), Times.Once);
        }

        [Test]
        public void Update_CallingWithObjectNotInDatabase_ShouldNotSave()
        {
            //Arrange
            var actualSubscriber = new Subscriber { Id = Guid.NewGuid(), Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = string.Empty };
            var expectedSubscriber = new Subscriber { Id = Guid.NewGuid(), Email = "email2@admin.com", HeardFrom = HeardFromResources.WordOfMouth, ReasonForSignup = string.Empty };

            _repositoryMock.Setup(md => md.GetByID(actualSubscriber.Id)).Returns(actualSubscriber);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            _subscriberService.Update(expectedSubscriber);

            // Assert
            _repositoryMock.Verify(md => md.Update(It.IsAny<Subscriber>()), Times.Exactly(0));
        }

        [Test]
        public void Update_CallingWithNullObject_ReturnNull()
        {
            //Arrange
            Subscriber subscriber = null;

            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.Update(subscriber);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Delete_Calling_ShouldDelete()
        {
            //Arrange
            var actualSubscriber = new Subscriber { Id = Guid.NewGuid(), Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = "Advert" };

            _repositoryMock.Setup(md => md.GetByID(actualSubscriber.Id)).Returns(actualSubscriber);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.Delete(actualSubscriber.Id);

            // Assert
            _repositoryMock.Verify(md => md.Delete(It.IsAny<Subscriber>()), Times.Once);
        }

        [Test]
        public void Delete_SendEmptyGuid_ReturnFalse()
        {
            //Arrange
            Guid subscriberId = Guid.Empty;

            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.Delete(subscriberId);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Delete_CallingWithObjectNotInDatabase_ReturnFalse()
        {
            //Arrange
            var actualSubscriber = new Subscriber { Id = Guid.NewGuid(), Email = "email1@admin.com", HeardFrom = HeardFromResources.Advert, ReasonForSignup = "Advert" };
            var expectedSubscriber = new Subscriber { Id = Guid.NewGuid(), Email = "email2@admin.com", HeardFrom = HeardFromResources.WordOfMouth, ReasonForSignup = "WordOfMouth" };

            _repositoryMock.Setup(md => md.GetByID(actualSubscriber.Id)).Returns(actualSubscriber);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.Delete(expectedSubscriber.Id);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsExist_SendExistEmail_ReturnTrue()
        {
            //Arrange
            string email = "email2@admin.com";
            IEnumerable<Subscriber> allSubscribers = new List<Subscriber>()
            {
                new Subscriber {Id=Guid.NewGuid(),Email="email1@admin.com",HeardFrom=HeardFromResources.Advert,ReasonForSignup="Advert" },
                new Subscriber {Id=Guid.NewGuid(),Email="email2@admin.com",HeardFrom=HeardFromResources.WordOfMouth,ReasonForSignup="Word Of Mouth" },
                new Subscriber {Id=Guid.NewGuid(),Email="email3@admin.com",HeardFrom=HeardFromResources.Other,ReasonForSignup="Other"},
            };

            _repositoryMock.Setup(md => md.GetAll()).Returns(allSubscribers);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.IsExist(email);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsExist_SendEmptyString_ReturnFalse()
        {
            //Arrange
            string email = string.Empty;
            IEnumerable<Subscriber> allSubscribers = new List<Subscriber>()
            {
                new Subscriber {Id=Guid.NewGuid(),Email="email1@admin.com",HeardFrom=HeardFromResources.Advert,ReasonForSignup="Advert" },
                new Subscriber {Id=Guid.NewGuid(),Email="email2@admin.com",HeardFrom=HeardFromResources.WordOfMouth,ReasonForSignup="Word Of Mouth" },
                new Subscriber {Id=Guid.NewGuid(),Email="email3@admin.com",HeardFrom=HeardFromResources.Other,ReasonForSignup="Other"},
            };

            _repositoryMock.Setup(md => md.GetAll()).Returns(allSubscribers);
            _subscriberService = new SubscriberService(_unitOfWorkMock.Object, _repositoryMock.Object);

            //Act
            var result = _subscriberService.IsExist(email);

            // Assert
            Assert.That(result, Is.False);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _repositoryMock = new Mock<GenericRepository<Subscriber>>(_contextMock.Object);
        }
    }
}
