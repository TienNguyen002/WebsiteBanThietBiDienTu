import React from "react";
import { Pagination } from "antd";

const PageComponent = ({ metadata, onChange }) => {
  return (
    <>
      <Pagination
        total={metadata.totalItemCount}
        showTotal={(total, range) =>
          `${range[0]}-${range[1]} of ${total} items`
        }
        defaultPageSize={metadata.pageSize}
        defaultCurrent={metadata.pageNumber}
        onChange={onChange}
      />
    </>
  );
};

export default PageComponent;
