namespace Ancorupt
{
    // Класс для хранения характеристик системы
    class SystemInfo
    {
        public string Cpu { get; private set; }
        public string Bios { get; private set; }
        public string Disk { get; private set; }
        public string BaseBoard { get; private set; }

        public SystemInfo(string cpu, string bios, string disk, string baseboard)
        {
            Cpu = cpu;
            Bios = bios;
            Disk = disk;
            BaseBoard = baseboard;
        }
    }
}
