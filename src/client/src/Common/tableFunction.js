import { Table, Input, Button, Form, Space, Dropdown, Menu } from "antd";
import { DownOutlined } from "@ant-design/icons";
import FilterDropdown from "../Components/admin/management/FilterDropdown";

// const getColumnSearchProps = (dataIndex) => ({
//   filterDropdown: ({
//     setSelectedKeys,
//     selectedKeys,
//     confirm,
//     clearFilters,
//   }) => (
//     <div style={{ padding: 8 }}>
//       <Input
//         ref={(node) => {
//           searchInput = node;
//         }}
//         placeholder={`Search ${dataIndex}`}
//         value={selectedKeys[0]}
//         onChange={(e) =>
//           setSelectedKeys(e.target.value ? [e.target.value] : [])
//         }
//         onPressEnter={() => handleSearch(selectedKeys, confirm)}
//         style={{ width: 188, marginBottom: 8, display: "block" }}
//       />
//       <Button
//         type="primary"
//         onClick={() => handleSearch(selectedKeys, confirm)}
//         // icon={<Search />}
//         size="small"
//         style={{ width: 90, marginRight: 8 }}
//       >
//         Search
//       </Button>
//       <Button
//         onClick={() => handleReset(clearFilters)}
//         size="small"
//         style={{ width: 90 }}
//       >
//         Reset
//       </Button>
//     </div>
//   ),
//   filterIcon: (filtered) => (
//     <Search
//       filtered={filtered}
//       style={{ color: filtered ? "#1890ff" : undefined }}
//     />
//   ),
//   onFilterDropdownVisibleChange: (visible) => {
//     if (visible) {
//       setTimeout(() => searchInput.focus(), 100);
//     }
//   },
//   onFilter: (value, record) =>
//     record[dataIndex]
//       ? record[dataIndex]
//           .toString()
//           .toLowerCase()
//           .includes(value.toLowerCase())
//       : "",
//   render: (text) => <a>{text}</a>,
// });

export const getColumnFilterProps = (dataIndex, dataSource) => ({
  filterDropdown: ({ setSelectedKeys, selectedKeys, confirm }) => (
    <FilterDropdown
      dataIndex={dataIndex}
      dataSource={dataSource}
      selectedKeys={selectedKeys}
      setSelectedKeys={setSelectedKeys}
      confirm={confirm}
    />
  ),
  onFilter: (value, record) =>
    record[dataIndex]
      ? record[dataIndex].toString().toLowerCase().includes(value.toLowerCase())
      : "",
  render: (text) => <a>{text}</a>,
});
