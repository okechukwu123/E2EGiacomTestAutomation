namespace E2EGiacomTestAutomation.Configuration.TestConfigurationSection
{
    using System.Configuration;

    public class Pages : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public PageConfiguration this[int index]
        {
            get
            {
                return (PageConfiguration)this.BaseGet(index);
            }

            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }

                this.BaseAdd(index, value);
            }
        }

        public new PageConfiguration this[string name]
        {
            get
            {
                return (PageConfiguration)this.BaseGet(name);
            }
        }

        public void Add(PageConfiguration customElement)
        {
            this.BaseAdd(customElement);
        }

        public int IndexOf(PageConfiguration element)
        {
            return this.BaseIndexOf(element);
        }

        public void Remove(PageConfiguration url)
        {
            if (this.BaseIndexOf(url) >= 0)
            {
                this.BaseRemove(url.Name);
            }
        }

        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            this.BaseRemove(name);
        }

        public void Clear()
        {
            this.BaseClear();
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            this.BaseAdd(element, false);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PageConfiguration();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PageConfiguration)element).Name;
        }
    }
}
