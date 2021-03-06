import { useState, useEffect, useReducer, useMemo } from "react";
import UserService from "../../store/services/user.service";
import styled from 'styled-components'
import Table from '../../components/Table';
import { Link } from "react-router-dom";
import NurseCreate from "./NurseCreate"
import makeData from '../../contexts/makeData'
// ColumnSizing, Expanding, Filters, Grouping, Headers, Ordering, Pagination, Pinning, RowSelection, Sorting,
// Visibility, buildHeaderGroups, createTable, createTableFactory, createTableInstance, defaultColumnSizing,
// expandRows, flattenBy, functionalUpdate, getBatchGroups, getColumnFilteredRowModelSync, getCoreRowModelAsync,
// getCoreRowModelSync, getExpandedRowModel, getGlobalFilteredRowModelSync, getGroupedRowModelSync, getPaginationRowModel,
// getSortedRowModelSync, incrementalMemo, isFunction, isRowSelected, makeStateUpdater, memo, noop, passiveEventSupported,
// propGetter, render, selectRowsFn, shouldAutoRemoveFilter, useTableInstance

function NursesList() {
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

    const data = content;
    // const data = useMemo(() => content, [])

    const columns = useMemo(
        () =>
            [
                {
                    Header: 'Nurses',
                    columns: [
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
                        },
                        // {
                        //   Header: 'Birthday',
                        //   accessor: 'birthday',
                        // },
                        // {
                        //   Header: 'Department',
                        //   accessor: 'department.name',
                        // },
                        // {
                        //   Header: 'Gender',
                        //   accessor: 'gender.name',
                        // },
                        // {
                        //   Header: 'Occupation',
                        //   accessor: 'occupation.name',
                        // }
                    ],
                },
            ],
        []
    )

    //use datas instead to get 1000 data
    // const datas = useMemo(() => makeData(1000), [])

    console.log(data);

    return (
        <>
            <div className="ReactTable -striped -highlight w-25 my-3">
                <div className="pagination-bottom">
                    <div className="-pagination">
                        <div className="-previous">
                            <Link to="/nurses/create" className="-btn">
                                + Create a new
                            </Link>
                        </div>
                    </div>
                </div>
            </div>
            <Table columns={columns} data={data} />
        </>
    );
};
export default NursesList;
