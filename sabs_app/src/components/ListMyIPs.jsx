import React from 'react'
import { useSelector } from 'react-redux';

export default function ListMyIPs() {



    const data = useSelector((state) => state.user_information);
    
    const ips = data.ips.split(",")
    console.log(ips)

    return (
        <div>
            <ul>
                {ips.map(ip=><li>{ip}</li>)}
            </ul>
        </div>
    )
}
