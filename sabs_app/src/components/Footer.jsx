import React from "react";
import { FooterStyle } from "../shared/styled/GlobalStyle";

export default function Footer(props) {
  return (
    <FooterStyle>
      <div
        className="text-center p-3"
        style={{ backgroundColor: "rgba(0, 0, 0, 0.2)" }}
      >
        ©
        <a className="text-dark" href={"#"}>
          SABS_APP @ 2021
        </a>
      </div>
    </FooterStyle>
  );
}
