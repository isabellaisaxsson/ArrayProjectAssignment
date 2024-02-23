using Statistics;

namespace StatisticsTester
{
    public class StatisticsTester
    {
        [Fact]
        public void TestMaximum()
        {
            Assert.Equal(5, StatisticsData.Maximum());
        }

        [Fact]
        public void TestMinimum()
        {
            Assert.Equal(1, StatisticsData.Minimum());
        }

        [Fact]
        public void TestMean()
        {
            Assert.Equal(3.0, StatisticsData.Mean());
        }

        [Fact]
        public void TestMedian()
        {
            Assert.Equal(3, StatisticsData.Median());
        }

        [Fact]
        public void TestMode()
        {
            Assert.Equal(new int[] { 4 }, StatisticsData.Mode());
        }

        [Fact]
        public void TestRange()
        {
            Assert.Equal(4, StatisticsData.Range());
        }

        [Fact]
        public void TestStandardDeviation()
        {
            Assert.Equal(1.4, StatisticsData.StandardDeviation(), 1);
        }
    }
}
