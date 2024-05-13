export const formatVND = (number) => {
  return new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
  }).format(number);
};

export const convertDate = (inputDate) => {
  let date = new Date(inputDate);

  let year = date.getFullYear();
  let month = date.getMonth() + 1;
  let day = date.getDate();

  return day + "/" + month + "/" + year;
};

export const splitUrl = (url) => {
  url.split("/").slice(-3).join("/");
};

export const convertObjToQueryString = function (obj) {
  var str = [];
  for (var p in obj)
    if (obj.hasOwnProperty(p)) {
      str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
    }
  return str.join("&");
};

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
