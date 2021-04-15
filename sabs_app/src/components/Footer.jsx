import React from "react";

export default function Footer(props) {
  console.log(props);
  return (
    <div
      className={props?.willBeFix ? "fixed-bottom" : "bottom"}
      style={{ gridArea: "3 / 1 / 4 / 2 " }}
    >
      <div
        className="text-center p-3"
        style={{ backgroundColor: "rgba(0, 0, 0, 0.2)" }}
      >
        ©
        <a className="text-dark" href={"#"}>
          SABS_APP @ 2021
        </a>
      </div>
    </div>
  );
}
