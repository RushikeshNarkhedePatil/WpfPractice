using System.Collections.ObjectModel;

namespace ModBusGUI.ViewModels
{
    /// <summary>
    /// handle list view items
    /// </summary>
    public class ItemHandler
    {
        public ItemHandler()
        {
            Items = new ObservableCollection<Item>();
            Read = new ObservableCollection<ReadItem>();
            WriteMCoil = new ObservableCollection<WriteItem>();
            AutoCoil = new ObservableCollection<AutoCoilItem>();
            AutoInput = new ObservableCollection<AutoInputItem>();
        }

        public ObservableCollection<Item> Items { get; private set; }
        public ObservableCollection<WriteItem> WriteMCoil { get; private set; }
        public ObservableCollection<ReadItem> Read { get; private set; }
        public ObservableCollection<AutoCoilItem> AutoCoil { get; private set; }
        public ObservableCollection<AutoInputItem> AutoInput { get; private set; }

        public void Add(Item item)
        {
            Items.Add(item);
        }
        public void ReadAdd(ReadItem item)
        {
            Read.Add(item);
        }
        public void WriteMAdd(WriteItem item)
        {
            WriteMCoil.Add(item);
        }
        public void AutoCoilAdd(AutoCoilItem item)
        {
            AutoCoil.Add(item);
        }
        public void AutoInputAdd(AutoInputItem item)
        {
            AutoInput.Add(item);
        }
    }
    //******************************Set List View  Values*******************************//
    public class WriteItem
    {
        public WriteItem(string name)
        {
            WriteMCoil = name;
        }
        public string WriteMCoil { get; set; }
    }
    public class ReadItem
    {
        public ReadItem(string name)
        {
            Read = name;
        }
        public string Read { get; set; }
    }
    public class AutoCoilItem
    {
        public AutoCoilItem(string name)
        {
            ACName = name;
        }
        public string ACName { get; set; }
    }

    public class AutoInputItem
    {
        public AutoInputItem(string name)
        {
            AIName = name;
        }
        public string AIName { get; set; }
    }

    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
