﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BindingToRelationalData
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PeopleDB")]
	public partial class DataClassesPeopleDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPeople(People instance);
    partial void UpdatePeople(People instance);
    partial void DeletePeople(People instance);
    #endregion
		
		public DataClassesPeopleDataContext() : 
				base(global::BindingToRelationalData.Properties.Settings.Default.PeopleDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPeopleDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPeopleDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPeopleDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesPeopleDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<People> Peoples
		{
			get
			{
				return this.GetTable<People>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.People")]
	public partial class People : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PersonID;
		
		private string _PersonName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPersonIDChanging(int value);
    partial void OnPersonIDChanged();
    partial void OnPersonNameChanging(string value);
    partial void OnPersonNameChanged();
    #endregion
		
		public People()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PersonID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PersonID
		{
			get
			{
				return this._PersonID;
			}
			set
			{
				if ((this._PersonID != value))
				{
					this.OnPersonIDChanging(value);
					this.SendPropertyChanging();
					this._PersonID = value;
					this.SendPropertyChanged("PersonID");
					this.OnPersonIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PersonName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PersonName
		{
			get
			{
				return this._PersonName;
			}
			set
			{
				if ((this._PersonName != value))
				{
					this.OnPersonNameChanging(value);
					this.SendPropertyChanging();
					this._PersonName = value;
					this.SendPropertyChanged("PersonName");
					this.OnPersonNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
