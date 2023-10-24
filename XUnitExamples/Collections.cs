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
    public class GuidGeneratorOne: IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public GuidGeneratorOne(ITestOutputHelper outputHelper)
        {
            _guidGenerator = new GuidGenerator();
            _outputHelper = outputHelper;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }
        public void Dispose()
        {
            _outputHelper.WriteLine("disposed with classfixture");
        }
    }

    // when we use classficture we tell xunit which should remain same for all the tests in this class 
    public class GuidGeneratorTwo : IClassFixture<GuidGenerator>, IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public GuidGeneratorTwo(ITestOutputHelper outputHelper, GuidGenerator guidGenerator)
        {
            _outputHelper = outputHelper;
            _guidGenerator = guidGenerator;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuidTestThree(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
        }
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void GuidTestfour(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
        } 
        
        [Theory]
        [ClassData(typeof(ClassTestDataForCollections))]
        public void GuidTestfive(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
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

    [Collection("mycollectiondef")]
    public class GuidGeneratorwithcollectionone : IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public GuidGeneratorwithcollectionone(ITestOutputHelper outputHelper, GuidGenerator guidGenerator)
        {
            _outputHelper = outputHelper;
            _guidGenerator = guidGenerator;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuidTestThree(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
        }
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void GuidTestfour(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
        } 
        
        [Theory]
        [ClassData(typeof(ClassTestDataForCollections))]
        public void GuidTestfive(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
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
     [Collection("mycollectiondef")]
    public class GuidGeneratorwithcollectionTwo : IDisposable
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _outputHelper;

        public GuidGeneratorwithcollectionTwo(ITestOutputHelper outputHelper, GuidGenerator guidGenerator)
        {
            _outputHelper = outputHelper;
            _guidGenerator = guidGenerator;
        }
        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }
        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"Guid was : {guid}");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GuidTestThree(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
        }
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void GuidTestfour(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
        } 
        
        [Theory]
        [ClassData(typeof(ClassTestDataForCollections))]
        public void GuidTestfive(int somenum)
        {
            var guid = _guidGenerator.RandomGuid;
            _outputHelper.WriteLine($"theory input : {somenum} Guid was : {guid}");
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
    }


    [CollectionDefinition("mycollectiondef")]
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator> { }
}
