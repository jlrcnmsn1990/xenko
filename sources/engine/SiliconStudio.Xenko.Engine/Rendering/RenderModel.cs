using System.Collections.Generic;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Engine;
using SiliconStudio.Xenko.Graphics;
using SiliconStudio.Xenko.Rendering;
using SiliconStudio.Xenko.Rendering.Materials;

namespace SiliconStudio.Xenko.Rendering
{
    public struct ActiveRenderStage
    {
        public bool Active { get { return EffectName != null; } }

        public string EffectName;

        public ActiveRenderStage(string effectName)
        {
            EffectName = effectName;
        }
    }

    /// <summary>
    /// Used by <see cref="MeshRenderFeature"/> to render a <see cref="Mesh"/>.
    /// </summary>
    [DefaultPipelinePlugin(typeof(MeshPipelinePlugin))]
    public class RenderMesh : RenderObject
    {
        public RenderModel RenderModel;

        /// <summary>
        /// Underlying mesh, can be accessed only during <see cref="RenderFeature.Extract"/> phase.
        /// </summary>
        public Mesh Mesh;

        // Material
        // TODO: Extract with MaterialRenderFeature
        public Material Material;
        internal MaterialRenderFeature.MaterialInfo MaterialInfo;

        public bool IsShadowCaster;
        public bool IsShadowReceiver;

        // TODO: Skinning

        public Matrix World = Matrix.Identity;
    }

    public class RenderModel
    {
        public readonly ModelComponent ModelComponent;
        public Model Model;
        public RenderMesh[] Meshes;

        public RenderModel(ModelComponent modelComponent)
        {
            ModelComponent = modelComponent;
        }
    }
}