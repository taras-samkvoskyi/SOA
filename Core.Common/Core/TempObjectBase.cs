using Core.Common.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Common.Core
{
    public class TempObjectBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler _PropertyChanged;
        List<PropertyChangedEventHandler> _PropertyChangedSubscribers = new List<PropertyChangedEventHandler>();

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!_PropertyChangedSubscribers.Contains(value))
                {
                    _PropertyChanged += value;
                    _PropertyChangedSubscribers.Add(value);
                }
            }

            remove
            {
                _PropertyChanged -= value;
                _PropertyChangedSubscribers.Remove(value);
            }
        }

        bool _IsDirty;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool makeDirty)
        {
            if (_PropertyChanged != null)
            {
                _PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            if (makeDirty)
                _IsDirty = true;
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> preopertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(preopertyExpression);
            OnPropertyChanged(propertyName);
        }

        public bool IsDirty
        {
            get { return _IsDirty; }
            set { _IsDirty = value; }
        }

        protected List<TempObjectBase> GetDirtyObjects()
        {
            var dirtyObjects = new List<TempObjectBase>();

            WalkObjectGraph(
                o =>
                {
                    if (o.IsDirty)
                        dirtyObjects.Add(o);
                    return false;
                }, coll => { });

            return dirtyObjects;
        }

        protected void WalkObjectGraph (Func<TempObjectBase, bool> snipperForObject,
            Action<IList> snippetForCollection,
            params string[] exempProperies)
        {
            var dirtyObjects = new List<TempObjectBase>();

            var visited = new List<TempObjectBase>();
            Action<TempObjectBase> walk = null;

            List<String> exemptions = new List<string>();
            if (exempProperies != null)
                exemptions = exempProperies.ToList();

            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    if (o.IsDirty)
                        dirtyObjects.Add(o);

                    bool exitWalk = snipperForObject.Invoke(o);

                    if (!exitWalk)
                    {
                        PropertyInfo[] properties = new PropertyInfo[0];
                        foreach (PropertyInfo property in properties)
                        {
                            if (!exemptions.Contains(property.Name))
                            {
                                if (property.PropertyType.IsSubclassOf(typeof(TempObjectBase)))
                                {
                                    var obj = (TempObjectBase)(property.GetValue(o, null));
                                    walk(obj);
                                }
                                else
                                {
                                    IList coll = property.GetValue(o, null) as IList;
                                    if (coll != null)
                                    {
                                        snippetForCollection.Invoke(coll);

                                        foreach (object item in coll)
                                        {
                                            if (item is TempObjectBase)
                                                walk((TempObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }

                    }

                }
            };
            walk(this);            
        }
    }
}
