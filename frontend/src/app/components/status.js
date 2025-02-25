import { tripStatus } from "../models/tripStatus";

export default function StatusText({ tripStatusNumber }) {
    const statusColors = {
        0: "bg-blue-200 text-blue-800", 
        1: "bg-green-200 text-green-800",
        2: "bg-gray-200 text-gray-800", 
        3: "bg-yellow-200 text-yellow-800", 
    };

    const currentStatusColor = statusColors[tripStatusNumber];

    return (
        <div className="my-5">
            <span className={`inline-block ${currentStatusColor} text-sm font-semibold px-3 py-1 rounded-full`}>
                Статус: {tripStatus[tripStatusNumber]}
            </span>
        </div>
    );
}