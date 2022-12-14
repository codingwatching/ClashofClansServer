namespace Supercell.Magic.Servers.Core.Network.Message.Session.Change
{
    using Supercell.Magic.Logic.Avatar;
    using Supercell.Magic.Logic.Message.Alliance;
    using Supercell.Magic.Titan.DataStream;

    public class TownHallLevelAvatarChange : AvatarChange
    {
        public int Level { get; set; }

        public override void Decode(ByteStream stream)
        {
            this.Level = stream.ReadVInt();
        }

        public override void Encode(ByteStream stream)
        {
            stream.WriteVInt(this.Level);
        }

        public override void ApplyAvatarChange(LogicClientAvatar avatar)
        {
            avatar.SetTownHallLevel(this.Level);
        }

        public override void ApplyAvatarChange(AllianceMemberEntry memberEntry)
        {
        }

        public override AvatarChangeType GetAvatarChangeType()
        {
            return AvatarChangeType.TOWN_HALL_LEVEL;
        }
    }
}