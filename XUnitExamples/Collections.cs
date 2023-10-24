using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace XUnitExamples
{
    // The constructor is being initiated for each test(Fact) so in this case we will see
    // different guids in each sine the test context is new for each test 
    public class NoFixture_1 : IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public NoFixture_1(ITestOutputHelper outputHelper)
        {
            _guidGenerator = new GuidGenerator();
            _outputHelper = outputHelper;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        public void Dispose()
        {
            _outputHelper.WriteLine("disposed with classfixture");
        }
    } 


    // when we use classficture we tell xunit which should remain same for all the tests in this class 
    public class WithClassFixture_1 : IClassFixture<GuidGenerator>, IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public WithClassFixture_1(ITestOutputHelper outputHelper, GuidGenerator guidGenerator)
        {
            _outputHelper = outputHelper;
            _guidGenerator = guidGenerator;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuidTestThree(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void GuidTestfour(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [ClassData(typeof(ClassTestDataForCollections))]
        public void GuidTestfive(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }


        public static IEnumerable<object[]> MemberTestData()
        {
            yield return new object[] { 4 };
            yield return new object[] { 5 };
            yield return new object[] { 6 };
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("disposed with classfixture");
        }
    } 
    
    public class WithClassFixture_2 : IClassFixture<GuidGenerator>, IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public WithClassFixture_2(ITestOutputHelper outputHelper, GuidGenerator guidGenerator)
        {
            _outputHelper = outputHelper;
            _guidGenerator = guidGenerator;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuidTestThree(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void GuidTestfour(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [ClassData(typeof(ClassTestDataForCollections))]
        public void GuidTestfive(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }


        public static IEnumerable<object[]> MemberTestData()
        {
            yield return new object[] { 4 };
            yield return new object[] { 5 };
            yield return new object[] { 6 };
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("disposed with classfixture");
        }
    }

    [Collection("GuidGenerator_collection")]
    public class WithCollectionFixture_1 : IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public WithCollectionFixture_1(ITestOutputHelper outputHelper, GuidGenerator guidGenerator)
        {
            _outputHelper = outputHelper;
            _guidGenerator = guidGenerator;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuidTestThree(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void GuidTestfour(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [ClassData(typeof(ClassTestDataForCollections))]
        public void GuidTestfive(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }


        public static IEnumerable<object[]> MemberTestData()
        {
            yield return new object[] { 4 };
            yield return new object[] { 5 };
            yield return new object[] { 6 };
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("disposed with classfixture");
        }
    }
    [Collection("GuidGenerator_collection")]
    public class WithCollectionFixture_2 : IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public WithCollectionFixture_2(ITestOutputHelper outputHelper, GuidGenerator guidGenerator)
        {
            _outputHelper = outputHelper;
            _guidGenerator = guidGenerator;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuidTestThree(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            var time = _guidGenerator.Date;
            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void GuidTestfour(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }

        [Theory]
        [ClassData(typeof(ClassTestDataForCollections))]
        public void GuidTestfive(int somenum)
        {
            var guid = _guidGenerator.RandomGuid; 
            var time = _guidGenerator.Date;

            _outputHelper.WriteLine($"Guid was : {guid}");
            _outputHelper.WriteLine($"Time was : {time}");
        }


        public static IEnumerable<object[]> MemberTestData()
        {
            yield return new object[] { 4 };
            yield return new object[] { 5 };
            yield return new object[] { 6 };
        }

        public void Dispose()
        {
            _outputHelper.WriteLine("disposed with classfixture");
        }
    }


    //helpers 
    public class GuidGenerator
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
        public long Date { get; } = DateTime.UtcNow.Ticks;
    }


    [CollectionDefinition("GuidGenerator_collection")]
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator> { }
}
