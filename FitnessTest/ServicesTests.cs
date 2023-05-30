using Fitness.Services;
using FluentAssertions;
using Moq;

namespace FitnessTest
{
    public class ServicesTests
    {
        private readonly Mock<ISettingsService> _settingsServiceMock;
        private readonly IFollowsService _followsService;
        private readonly IUsersService _usersService;

        public ServicesTests()
        {
            _settingsServiceMock = new Mock<ISettingsService>();
            _settingsServiceMock.SetupGet(x => x.BasePath).Returns("https://dkz1z6k5-7125.euw.devtunnels.ms");
            _usersService = new UsersService(_settingsServiceMock.Object);
            _followsService = new FollowsService(_settingsServiceMock.Object);
        }

        [Fact]
        public async Task Success_GetAllUsersCount_EqualsFour()
        {
            var totalUsers = await _usersService.ApiUsersGet();
            totalUsers.Count.Should().Be(4);
        }

        [Fact]
        public async Task Success_GetUserFollows_FollowingUserIdSame()
        {
            var follows = await _followsService.ApiFollowsIdGet("7a2e0b41-5308-4eb1-8b79-d22e57d8878a");
            follows[0].FollowingUserId.Should().Be("7a2e0b41-5308-4eb1-8b79-d22e57d8878a");
        }
    }
}