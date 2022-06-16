import { useState, useEffect, useReducer, useMemo } from "react";
import UserService from "../../store/services/user.service";
import styled from 'styled-components'
import Table from '../../components/Table'
// ColumnSizing, Expanding, Filters, Grouping, Headers, Ordering, Pagination, Pinning, RowSelection, Sorting,
// Visibility, buildHeaderGroups, createTable, createTableFactory, createTableInstance, defaultColumnSizing,
// expandRows, flattenBy, functionalUpdate, getBatchGroups, getColumnFilteredRowModelSync, getCoreRowModelAsync,
// getCoreRowModelSync, getExpandedRowModel, getGlobalFilteredRowModelSync, getGroupedRowModelSync, getPaginationRowModel,
// getSortedRowModelSync, incrementalMemo, isFunction, isRowSelected, makeStateUpdater, memo, noop, passiveEventSupported,
// propGetter, render, selectRowsFn, shouldAutoRemoveFilter, useTableInstance

function NursesBoard() {
  const [content, setContent] = useState([]);
  useEffect(() => {
    UserService.getNursesBoard().then(
      (response) => {
        setContent(response.data);
      },
      (error) => {
        const _content =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();
        setContent(_content);
      }
    );
  }, []);

  const data = useMemo(() => content, [])

  const columns = useMemo(
    () =>
      [
        {
          Header: 'Name',
          accessor: 'name',
        },
        {
          Header: 'Last Name',
          accessor: 'surname',
        },
        {
          Header: 'Age',
          accessor: 'age',
        },
        {
          Header: 'Email',
          accessor: 'email',
        }
        // {
        //   Header: 'Birthday',
        //   accessor: 'birthday',
        // },
        // {
        //   Header: 'Department',
        //   accessor: 'department',
        // },
        // {
        //   Header: 'Gender',
        //   accessor: 'gender',
        // },
        // {
        //   Header: 'Occupation',
        //   accessor: 'occupation',
        // }
      ],
    []
  )

  return (
    <>
      <div className="row">
        <div className="col-12 col">
          <div className="page-title-box d-flex align-items-start align-items-center justify-content-between">
            <h4 className="page-title mb-0 font-size-18">Doctors</h4>
            <div className="page-title-right">
              <ol className="breadcrumb m-0">
                <li className="breadcrumb-item">
                  <a href="/dashboard">Dashboard</a>
                </li>
              </ol>
            </div>
          </div>
        </div>
      </div>
      <div className="row">
        <div className="col-lg-12">
          <div className="card">
            <div className="card-body">
              <Table columns={columns} data={data} />
            </div>
          </div>
        </div>
      </div>
    </>
  );
};
export default NursesBoard;
