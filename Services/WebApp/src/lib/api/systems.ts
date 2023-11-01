export type System = {
	id: string;
	name: string;
	provider: string;
	date: string;
	status: 'Approved' | 'Pending' | 'Rejected';
	description?: string;
	description2?: string;
};

export const systems: System[] = [
	{
		id: '876364',
		name: 'AI System 1',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Approved',
		description:
			'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Distinctio iusto qui necessitatibus voluptatum itaque eaque pariatur! Veritatis repellendus possimus iste corporis pariatur labore vitae et nemo aliquam laboriosam nam aliquid, repellat ipsa odio odit dolorum non consequatur quam magni maxime recusandae cupiditate. Quis laborum distinctio error sequi! Eum ad iure unde explicabo ea voluptatibus esse debitis sunt porro, in, necessitatibus modi nobis quidem placeat vitae fugiat officiis repudiandae temporibus veniam! Esse animi quibusdam sequi quis, nam consectetur accusantium obcaecati distinctio? Vero laudantium aspernatur magni nobis optio ducimus neque alias et nemo sunt! Ipsam aut debitis, recusandae minus sapiente quae necessitatibus.',
		description2:
			'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Natus quis odio officia unde fugit ea, eligendi asperiores laboriosam doloremque perferendis cum ipsum perspiciatis suscipit possimus cumque, reprehenderit deserunt omnis nisi? Explicabo nihil esse dolorem tempora, id quidem accusantium officia distinctio beatae, dignissimos at possimus unde quasi odit vel culpa, nam error consequatur atque omnis dolores. Quas tenetur eius, provident temporibus autem nulla reiciendis assumenda laborum? Impedit distinctio assumenda enim laboriosam fugit natus! Voluptatibus dolor ducimus minima at commodi error rerum incidunt aut? Maxime, nobis alias totam veritatis officiis sapiente facere inventore libero mollitia aliquam praesentium, sed placeat. Eligendi exercitationem dolore a officia, magni maxime nostrum minima fuga optio qui animi quos pariatur nesciunt eaque harum sint commodi ipsam tempore tempora consequuntur modi repellendus in neque ea. Vero excepturi veritatis ratione.'
	},
	{
		id: '876365',
		name: 'AI System 2',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Pending',
		description:
			'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Distinctio iusto qui necessitatibus voluptatum itaque eaque pariatur! Veritatis repellendus possimus iste corporis pariatur labore vitae et nemo aliquam laboriosam nam aliquid, repellat ipsa odio odit dolorum non consequatur quam magni maxime recusandae cupiditate. Quis laborum distinctio error sequi! Eum ad iure unde explicabo ea voluptatibus esse debitis sunt porro, in, necessitatibus modi nobis quidem placeat vitae fugiat officiis repudiandae temporibus veniam! Esse animi quibusdam sequi quis, nam consectetur accusantium obcaecati distinctio? Vero laudantium aspernatur magni nobis optio ducimus neque alias et nemo sunt! Ipsam aut debitis, recusandae minus sapiente quae necessitatibus.',
		description2:
			'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Natus quis odio officia unde fugit ea, eligendi asperiores laboriosam doloremque perferendis cum ipsum perspiciatis suscipit possimus cumque, reprehenderit deserunt omnis nisi? Explicabo nihil esse dolorem tempora, id quidem accusantium officia distinctio beatae, dignissimos at possimus unde quasi odit vel culpa, nam error consequatur atque omnis dolores. Quas tenetur eius, provident temporibus autem nulla reiciendis assumenda laborum? Impedit distinctio assumenda enim laboriosam fugit natus! Voluptatibus dolor ducimus minima at commodi error rerum incidunt aut? Maxime, nobis alias totam veritatis officiis sapiente facere inventore libero mollitia aliquam praesentium, sed placeat. Eligendi exercitationem dolore a officia, magni maxime nostrum minima fuga optio qui animi quos pariatur nesciunt eaque harum sint commodi ipsam tempore tempora consequuntur modi repellendus in neque ea. Vero excepturi veritatis ratione.'
	},
	{
		id: '876366',
		name: 'AI System 3',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Pending',
		description:
			'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Distinctio iusto qui necessitatibus voluptatum itaque eaque pariatur! Veritatis repellendus possimus iste corporis pariatur labore vitae et nemo aliquam laboriosam nam aliquid, repellat ipsa odio odit dolorum non consequatur quam magni maxime recusandae cupiditate. Quis laborum distinctio error sequi! Eum ad iure unde explicabo ea voluptatibus esse debitis sunt porro, in, necessitatibus modi nobis quidem placeat vitae fugiat officiis repudiandae temporibus veniam! Esse animi quibusdam sequi quis, nam consectetur accusantium obcaecati distinctio? Vero laudantium aspernatur magni nobis optio ducimus neque alias et nemo sunt! Ipsam aut debitis, recusandae minus sapiente quae necessitatibus.',
		description2:
			'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Natus quis odio officia unde fugit ea, eligendi asperiores laboriosam doloremque perferendis cum ipsum perspiciatis suscipit possimus cumque, reprehenderit deserunt omnis nisi? Explicabo nihil esse dolorem tempora, id quidem accusantium officia distinctio beatae, dignissimos at possimus unde quasi odit vel culpa, nam error consequatur atque omnis dolores. Quas tenetur eius, provident temporibus autem nulla reiciendis assumenda laborum? Impedit distinctio assumenda enim laboriosam fugit natus! Voluptatibus dolor ducimus minima at commodi error rerum incidunt aut? Maxime, nobis alias totam veritatis officiis sapiente facere inventore libero mollitia aliquam praesentium, sed placeat. Eligendi exercitationem dolore a officia, magni maxime nostrum minima fuga optio qui animi quos pariatur nesciunt eaque harum sint commodi ipsam tempore tempora consequuntur modi repellendus in neque ea. Vero excepturi veritatis ratione.'
	},
	{
		id: '876367',
		name: 'AI System 4',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Approved',
		description:
			'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Distinctio iusto qui necessitatibus voluptatum itaque eaque pariatur! Veritatis repellendus possimus iste corporis pariatur labore vitae et nemo aliquam laboriosam nam aliquid, repellat ipsa odio odit dolorum non consequatur quam magni maxime recusandae cupiditate. Quis laborum distinctio error sequi! Eum ad iure unde explicabo ea voluptatibus esse debitis sunt porro, in, necessitatibus modi nobis quidem placeat vitae fugiat officiis repudiandae temporibus veniam! Esse animi quibusdam sequi quis, nam consectetur accusantium obcaecati distinctio? Vero laudantium aspernatur magni nobis optio ducimus neque alias et nemo sunt! Ipsam aut debitis, recusandae minus sapiente quae necessitatibus.',
		description2:
			'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Natus quis odio officia unde fugit ea, eligendi asperiores laboriosam doloremque perferendis cum ipsum perspiciatis suscipit possimus cumque, reprehenderit deserunt omnis nisi? Explicabo nihil esse dolorem tempora, id quidem accusantium officia distinctio beatae, dignissimos at possimus unde quasi odit vel culpa, nam error consequatur atque omnis dolores. Quas tenetur eius, provident temporibus autem nulla reiciendis assumenda laborum? Impedit distinctio assumenda enim laboriosam fugit natus! Voluptatibus dolor ducimus minima at commodi error rerum incidunt aut? Maxime, nobis alias totam veritatis officiis sapiente facere inventore libero mollitia aliquam praesentium, sed placeat. Eligendi exercitationem dolore a officia, magni maxime nostrum minima fuga optio qui animi quos pariatur nesciunt eaque harum sint commodi ipsam tempore tempora consequuntur modi repellendus in neque ea. Vero excepturi veritatis ratione.'
	},
	{
		id: '876368',
		name: 'AI System 5',
		provider: 'Google Cloud',
		date: '2021-08-12',
		status: 'Pending',
		description:
			'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Distinctio iusto qui necessitatibus voluptatum itaque eaque pariatur! Veritatis repellendus possimus iste corporis pariatur labore vitae et nemo aliquam laboriosam nam aliquid, repellat ipsa odio odit dolorum non consequatur quam magni maxime recusandae cupiditate. Quis laborum distinctio error sequi! Eum ad iure unde explicabo ea voluptatibus esse debitis sunt porro, in, necessitatibus modi nobis quidem placeat vitae fugiat officiis repudiandae temporibus veniam! Esse animi quibusdam sequi quis, nam consectetur accusantium obcaecati distinctio? Vero laudantium aspernatur magni nobis optio ducimus neque alias et nemo sunt! Ipsam aut debitis, recusandae minus sapiente quae necessitatibus.',
		description2:
			'Lorem ipsum dolor sit amet consectetur, adipisicing elit. Natus quis odio officia unde fugit ea, eligendi asperiores laboriosam doloremque perferendis cum ipsum perspiciatis suscipit possimus cumque, reprehenderit deserunt omnis nisi? Explicabo nihil esse dolorem tempora, id quidem accusantium officia distinctio beatae, dignissimos at possimus unde quasi odit vel culpa, nam error consequatur atque omnis dolores. Quas tenetur eius, provident temporibus autem nulla reiciendis assumenda laborum? Impedit distinctio assumenda enim laboriosam fugit natus! Voluptatibus dolor ducimus minima at commodi error rerum incidunt aut? Maxime, nobis alias totam veritatis officiis sapiente facere inventore libero mollitia aliquam praesentium, sed placeat. Eligendi exercitationem dolore a officia, magni maxime nostrum minima fuga optio qui animi quos pariatur nesciunt eaque harum sint commodi ipsam tempore tempora consequuntur modi repellendus in neque ea. Vero excepturi veritatis ratione.'
	}
];

export const getSystem = async (id: string): Promise<System | undefined> => {
	const response = await fetch(`http://localhost:5050/api/system/${id}`);

	if (response.ok) {
		const system: System = await response.json();
		return system;
	}

	return undefined;
};

export const getSystemsByStatus = async (status: string): Promise<System[]> => {
	const response = await fetch(`http://localhost:5050/api/system?status=${status}`);

	if (response.ok) {
		const systems: System[] = await response.json();
		return systems;
	}

	return [];
}

export const getSystems = async (): Promise<System[]> => {
	const response = await fetch(`http://localhost:5050/api/system`);

	if (response.ok) {
		const systems: System[] = await response.json();
		return systems;
	}

	return [];
};

export const editSystem = async (system: System): Promise<System | undefined> => {
	const response = await fetch(`http://localhost:5050/api/system/${system.id}`, {
		method: 'PUT',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(system)
	});

	if (response.ok) {
		const system: System = await response.json();

		systems.forEach((s) => {
			if (s.id === system.id) {
				s.name = system.name;
				s.provider = system.provider;
				s.date = system.date;
				s.status = system.status;
				s.description = system.description;
				s.description2 = system.description2;
			}
		});

		return system;
	}

	return undefined;
};

export const setSystemStatusToApproved = async (id: string): Promise<System | undefined> => {
	const response = await fetch(`http://localhost:5050/api/system/${id}/approve`);

	if (response.ok) {
		const system: System = await response.json();

		systems.forEach((s) => {
			if (s.id === system.id) {
				s.status = system.status;
			}
		});

		return system;
	}

	return undefined;
};

export const setSystemStatusToRejected = async (id: string): Promise<System | undefined> => {
	const response = await fetch(`http://localhost:5050/api/system/${id}/reject`);

	if (response.ok) {
		const system: System = await response.json();

		systems.forEach((s) => {
			if (s.id === system.id) {
				s.status = system.status;
			}
		});

		return system;
	}

	return undefined;
};
