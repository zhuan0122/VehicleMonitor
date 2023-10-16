using Microsoft.EntityFrameworkCore;
using Moq;

namespace VehicleStatusMicroservice.Tests.ServiceTests
{
    public static class DbSetMock
    {
        public static DbSet<T> GetDbSetMock<T>(List<T> data) where T : class
        {
            var queryable = data.AsQueryable();

            var mockDbSet = new Mock<DbSet<T>>();

            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockDbSet.Object;
        }
    }
}