using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePustaka
{
    public class MembersService
    {
        private List<Member> members;

        public MembersService()
        {
            members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            member.Id = members.Count + 1;
            members.Add(member);
            Console.WriteLine("Anggota berhasil ditambahkan.");
        }

        public void EditMember(int id, Member updatedMember)
        {
            var existingMember = members.Find(m => m.Id == id);
            if (existingMember != null)
            {
                existingMember.Name = updatedMember.Name;
                existingMember.Email = updatedMember.Email;
                existingMember.MembershipNumber = updatedMember.MembershipNumber;
                Console.WriteLine("Anggota berhasil diubah.");
            }
            else
            {
                Console.WriteLine("Anggota tidak ditemukan.");
            }
        }

        public void DeleteMember(int id)
        {
            var existingMember = members.Find(m => m.Id == id);
            if (existingMember != null)
            {
                members.Remove(existingMember);
                Console.WriteLine("Anggota berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("Anggota tidak ditemukan.");
            }
        }

        public List<Member> GetAllMembers()
        {
            return members;
        }

    }
}
