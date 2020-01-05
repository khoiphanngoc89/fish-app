using NFC.Application.Shared;
using System.Collections.Generic;

namespace NFC.Domain.Entities
{
    /// <summary>
    /// Defines the menu.
    /// </summary>
    /// <seealso cref="NFC.Application.Shared.IActiveMetadata" />
    public class Menu : DomainEntity<int>, IActiveMetadata
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the type of the menu.
        /// </summary>
        /// <value>
        /// The type of the menu.
        /// </value>
        public MenuType MenuType { get; set; }

        /// <summary>
        /// Gets or sets the has sub menu.
        /// </summary>
        /// <value>
        /// The has sub menu.
        /// </value>
        public bool HasSub { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets the sub menus.
        /// </summary>
        /// <value>
        /// The sub menus.
        /// </value>
        public virtual ICollection<SubMenu> SubMenus { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.SubMenus = new List<SubMenu>();
        }
    }
}