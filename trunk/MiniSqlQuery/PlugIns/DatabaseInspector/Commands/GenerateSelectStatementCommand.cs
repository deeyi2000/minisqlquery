﻿using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using MiniSqlQuery.Core;
using MiniSqlQuery.Core.DbModel;

namespace MiniSqlQuery.PlugIns.DatabaseInspector.Commands
{
	public class GenerateSelectStatementCommand : GenerateStatementCommandBase
	{
		public GenerateSelectStatementCommand()
			: base("Generate Select Statement")
		{
		}

		public override void Execute()
		{
			IQueryEditor editor = ActiveFormAsEditor;
			string tableName = Services.HostWindow.DatabaseInspector.RightClickedTableName;
			DbModelInstance model = Services.HostWindow.DatabaseInspector.DbSchema;

			if (tableName != null && editor != null)
			{
				StringWriter sql = new StringWriter();
				SqlWriter.WriteSelect(sql, GetTableByName(model, tableName));
				editor.InsertText(sql.ToString());
			}
		}
	}
}