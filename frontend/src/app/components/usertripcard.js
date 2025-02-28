import { useRouter } from 'next/navigation';
import React from 'react';
import StatusText from './status';

export default function UserTripCard ({ id, title, description, startPlace, endPlace, userName }) {
    const router = useRouter();

    return (
        <div className="w-[300px] rounded overflow-hidden border border-gray-700 bg-white m-4">
            <div className="px-6 pt-4">
                <a onClick={() => router.push(`/trips/${id}`) } className="font-bold cursor-pointer text-xl mb-2">
                    {title}
                </a>
                <p className="text-gray-700 text-base mb-4">
                    <b>Описание: </b>{description != "" ? description : "Отсутствует"}
                </p>
                <div className="text-gray-600 text-sm">
                    <p>
                        <b>Откуда: </b>{startPlace}
                    </p>
                    <p>
                        <b>Куда: </b>{endPlace}
                    </p>
                </div>
                <p className="text-gray-700 text-base my-4">
                    <b>Автор: </b>{userName}
                </p>
            </div>
        </div>
    );
}