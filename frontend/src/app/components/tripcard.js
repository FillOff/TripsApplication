import { useRouter } from 'next/navigation';
import React from 'react';
import StatusText from './status';

export default function TripCard ({ id, title, description, startDate, endDate, tripStatusNumber }) {
    const router = useRouter();

    return (
        <div className="w-[300px] rounded overflow-hidden border border-gray-700 bg-white m-4">
            <div className="px-6 pt-4">
                <a onClick={() => router.push(`/trips/${id}`) } className="font-bold cursor-pointer text-xl mb-2">
                    {title}
                </a>
                <p className="text-gray-700 text-base mb-4">
                    {description}
                </p>
                <div className="text-gray-600 text-sm">
                    <p>
                        Начало: {new Date(startDate).toLocaleString()}
                    </p>
                    <p>
                        Конец: {new Date(endDate).toLocaleString()}
                    </p>
                    <StatusText
                        tripStatusNumber={tripStatusNumber}
                    />
                </div>
            </div>
        </div>
    );
}