import { useTable, usePagination, useSortBy, useBlockLayout, useResizeColumns, useAbsoluteLayout } from 'react-table'
import { useMemo } from 'react'

function Table({ columns, data }) {

  const defaultColumn = useMemo(
    () => ({
      minWidth: 300,
      width: 200,
    }),
    []
  )

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    prepareRow,
    page,
    canPreviousPage,
    canNextPage,
    pageOptions,
    pageCount,
    gotoPage,
    nextPage,
    previousPage,
    setPageSize,
    useFilters,
    rows,
    state,
    resetResizing,
    state: { pageIndex, pageSize },
  } = useTable(
    {
      columns,
      data,
      initialState: { pageIndex: 2 },
      defaultColumn,
    },
    useSortBy,
    usePagination,
    useBlockLayout,
    useAbsoluteLayout,
    useResizeColumns,
  )



  return (
    <>
      <div className="ReactTable -striped -highlight">
        <div {...getTableProps()} className="rt-table">
          <div className="rt-thead -header" style={{ minWidth: '300px' }}>
            {headerGroups.map(headerGroup => (
              <div {...headerGroup.getHeaderGroupProps()} className="rt-tr">
                {headerGroup.headers.map(function (column, i) {
                  return <div key={i} className="rt-resizable-header -cursor-pointer rt-th" style={{ flex: '100 0 auto', width: '100px' }}><div {...column.getHeaderProps(column.getSortByToggleProps())} className="rt-resizable-header-content">{column.render('Header')}
                      <span>
                        {column.isSorted
                          ? column.isSortedDesc
                            ? ' 🔽'
                            : ' 🔼'
                          : ''}
                      </span>
                    </div>
                    {/* <div {...column.getResizerProps()}
                      className={`rt-resizer ${
                        column.isResizing ? 'isResizing' : ''
                      }`}>
                    </div> */}
                  </div>
                })}
              </div>
            ))}
          </div>
          <div  {...getTableBodyProps()} className="rt-tbody" style={{ minWidth: '300px' }}>
            {page.map((row, i) => {
              prepareRow(row)
              return (
                <div key={i} className="rt-tr-group" {...row.getRowProps()}>
                  <div key={i} {...row.getRowProps()} className={`rt-tr ${i % 2 === 0 ? ' -even' : '-odd'}`}>
                    {row.cells.map(function (cell, i) {
                      return <div  {...cell.getCellProps()} className="rt-td" style={{ flex: '100 0 auto', width: '100px' }}>{cell.render('Cell')}</div>
                    })}
                  </div>
                </div>
              )
            })}
          </div>
        </div>
        <div className="pagination-bottom">
          <div className="-pagination">
            <div className="-previous"><button onClick={() => previousPage()} disabled={!canPreviousPage} type="button" className="-btn">Previous</button></div>
            <button onClick={() => gotoPage(0)} disabled={!canPreviousPage}>
              {'<<'}
            </button>
            <div className="-center">
              <span className="-pageInfo">Page
                <div className="-pageJump">
                  <input
                    type="number"
                    defaultValue={pageIndex + 1}
                    onChange={e => {
                      const page = e.target.value ? Number(e.target.value) - 1 : 0
                      gotoPage(page)
                    }}
                    style={{ width: '100px' }}
                  />
                </div> of
                <span className="-totalPages"> {pageOptions.length}</span>
              </span>
              <span className="select-wrap -pageSizeOptions">
                <select
                  value={pageSize}
                  onChange={e => {
                    setPageSize(Number(e.target.value))
                  }}
                >
                  {[5, 10, 20, 30, 40, 50].map(pageSize => (
                    <option key={pageSize} value={pageSize}>
                      Show {pageSize}
                    </option>
                  ))}
                </select>
              </span>
            </div>
            <button onClick={() => gotoPage(pageCount - 1)} disabled={!canNextPage}>
              {'>>'}
            </button>
            <div className="-next"><button onClick={() => nextPage()} disabled={!canNextPage} type="button" className="-btn">Next</button></div>
          </div>
        </div>
        <div className="-loading">
          <div className="-loading-inner">Loading...</div>
        </div>
      </div>
    </>
  )
}

export default Table