using JustEat.Simples.NotificationStack.Messaging.Messages;
using JustEat.Simples.NotificationStack.Stack;
using JustEat.Testing;
using NSubstitute;
using NUnit.Framework;
using Tests.MessageStubs;

namespace Stack.UnitTests.FluentNotificationStackTests.Publishing
{
    public class WhenPublishing : FluentNotificationStackTestBase
    {
        private readonly Message _message = new GenericMessage();

        protected override void Given()
        {
        }

        protected override void When()
        {
            SystemUnderTest.Publish(_message);
        }

        [Then]
        public void TheMessageIsPublished()
        {
            NotificationStack.Received().Publish(_message);
        }

        [Then]
        public void TheComponentIsPopulatedOnMessage()
        {
            NotificationStack.Received().Publish(Arg.Is<GenericMessage>(x => x.RaisingComponent == Component));
        }

        [Then]
        public void TheTenantIsPopulatedOnMessage()
        {
            NotificationStack.Received().Publish(Arg.Is<GenericMessage>(x => x.Tenant == Tenant));
        }
    }
}