'use client'

import Map, { geocode } from '@/app/components/map';
import { createRoute } from '@/app/services/route';
import { createTrip } from '@/app/services/trips';
import { useRouter } from 'next/navigation';
import React, { useState } from 'react';

export default function NewTripPage() {
    const router = useRouter();
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [startDateTime, setStartDateTime] = useState("");
    const [endDateTime, setEndDateTime] = useState("");
    const [startPlace, setStartPlace] = useState("");
    const [endPlace, setEndPlace] = useState("");
    const [duration, setDuration] = useState(0);
    const [length, setLength] = useState(0);
    const [isClicked, setisClicked] = useState(false);

    return (
        <div className="w-full h-full px-5">
            <h1 className="text-3xl font-bold text-center my-5">Новая поездка</h1>
            <form 
                onSubmit={async (e) => {
                    e.preventDefault();

                    if (!isClicked) {
                        alert('Маршрут не составлен!');
                        return; 
                    }

                    if (startDateTime > endDateTime) {
                        alert('Некорректная дата!');
                        return;
                    }

                    const routeId = await createRoute(startPlace, endPlace, Math.floor(duration), length);
                    await createTrip(name, description, startDateTime, endDateTime, routeId); 
                    
                    router.push("/trips");
                }} 
                className="mx-auto p-4 space-y-4"
            >
                <div>
                    <label htmlFor="name" className="block text-sm font-medium text-gray-700">Название</label>
                    <input
                    type="text"
                    id="name"
                    onChange={(e) => {
                        setName(e.target.value);
                    }}
                    className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                    required
                    />
                </div>

                <div>
                    <label htmlFor="description" className="block text-sm font-medium text-gray-700">Описание поездки</label>
                    <textarea
                    id="description"
                    onChange={(e) => {
                        setDescription(e.target.value);
                    }}
                    className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                    />
                </div>
                
                <div className='space-y-4'>
                    <div>
                        <label htmlFor="startPlace" className="block text-sm font-medium text-gray-700">Начало пути</label>
                        <input
                        type="text"
                        id="startPlace"
                        className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                        required
                        />
                    </div>
                    <div>
                        <label htmlFor="endPlace" className="block text-sm font-medium text-gray-700">Конец пути</label>
                        <input
                        type="text"
                        id="endPlace"
                        className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                        required
                        />
                    </div>
                    <button
                        className="w-full mt-2 py-2 px-4 bg-gray-700 text-white font-medium rounded-md focus:bg-gray-500"
                        onClick={() => {
                            setStartPlace(document.getElementById('startPlace').value);
                            setEndPlace(document.getElementById('endPlace').value);
                            setisClicked(true);
                        }}

                        type='button'
                    >
                        Составить маршрут
                    </button>
                    <Map 
                        startPlace={startPlace}
                        endPlace={endPlace}
                        setLength={setLength}
                        setDuration={setDuration}
                    />
                </div>

                <div>
                    <label htmlFor="startDateTime" className="block text-sm font-medium text-gray-700">Дата и время начала пути</label>
                    <input
                    type="datetime-local"
                    id="startDateTime"
                    onChange={(e) => {
                        setStartDateTime(e.target.value);
                    }}
                    className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                    required
                    />
                </div>

                <div>
                    <label htmlFor="endDateTime" className="block text-sm font-medium text-gray-700">Дата и время конца пути</label>
                    <input
                    type="datetime-local"
                    id="endDateTime"
                    onChange={(e) => {
                        setEndDateTime(e.target.value);
                    }}
                    className="w-full px-4 py-2 border border-gray-700 rounded-lg"
                    required
                    />
                </div>

                <div>
                    <button
                        type="submit"
                        className="w-full py-2 px-4 bg-gray-700 text-white font-medium rounded-md focus:bg-gray-500"
                    >
                        Создать
                    </button>
                </div>
            </form>
        </div>
    );
}